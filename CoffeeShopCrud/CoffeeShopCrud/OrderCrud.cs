using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CoffeeShopCrud
{
    public partial class OrderCrud : Form
    {
        string connectionString = @"Server = DESKTOP-J6257UA; Database = CoffeeShop; Integrated Security = true";
     
        string customerName = "";
        string itemName = "";
        string price = "";
        string qty = "";
        public OrderCrud()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            customerName = cNameComboBox.Text;
            itemName = iComboBox.Text;
            price = priceTextBox.Text;
            qty = quantityTextBox.Text;

            if (customerName == "" || itemName == "" || price == "" || qty == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            else if (CheckIfNumeric(customerName))
            {
                MessageBox.Show("Please enter Customer name, not numeric value.");
                cNameComboBox.Text = "";
                return;
            }
            if (SelectCustomerName() == 1)
            {
                MessageBox.Show("This Customer is Already exist..");
                cNameComboBox.Text = "";
                return;
            }

            if (!CheckIfNumeric(price))
            {
                MessageBox.Show("Please enter numeric price value.");
                priceTextBox.Text = "";
                return;
            }
            else if (!CheckIfNumeric(qty))
            {
                MessageBox.Show("Please enter numeric Quantity value.");
                quantityTextBox.Text = "";
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "INSERT INTO Orders(CustomerName, ItemName, Price, Quantity) VALUES('" + customerName + "', '" + itemName + "'," + price + "," + qty + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    if (ShowData() == 1)
                    {
                        MessageBox.Show("Saved Successfully");
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Not Saved Data, Check Inserting Details");
                }
                sqlConnection.Close();
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (ShowData() == 0)
            {
                showDataGridView.DataSource = "";
                MessageBox.Show("There is no available Customer");
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            if (cNameComboBox.Text == "" || iComboBox.Text == "" || priceTextBox.Text == "" || quantityTextBox.Text == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            else if (CheckIfNumeric(customerName))
            {
                MessageBox.Show("Please enter Customer name, not numeric value.");
                cNameComboBox.Text = "";
                return;
            }

            if (!CheckIfNumeric(price))
            {
                MessageBox.Show("Please enter numeric price value.");
                priceTextBox.Text = "";
                return;
            }
            else if (!CheckIfNumeric(qty))
            {
                MessageBox.Show("Please enter numeric Quantity value.");
                quantityTextBox.Text = "";
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "UPDATE Orders SET CustomerName = '" + cNameComboBox.Text + "', ItemName = '" + iComboBox.Text + "',Price = " + priceTextBox.Text + ",Quantity = " + quantityTextBox.Text + "" +
                    "WHERE ID = " + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();

                if (isExecute > 0)
                {
                    if (ShowData() == 1)
                    {
                        MessageBox.Show("Updated Successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }
                sqlConnection.Close();
            }
            catch (Exception excp)
            {

                MessageBox.Show(excp.Message);
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("Please Select Id Field..");
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "DELETE FROM Orders WHERE ID = " + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();

                if (isExecute > 0)
                {
                    if (ShowData() == 1 || ShowData() == 0)
                    {
                        MessageBox.Show("Deleted Successfully");
                        return;
                    }
                }
                else
                {
                    if (showDataGridView.DataSource == "")
                    {
                        MessageBox.Show("There is no available data");
                        return;
                    }
                    MessageBox.Show("Please,,Select Correct ID");
                    return;
                }
                sqlConnection.Close();
            }
            catch (Exception excp)
            {

                MessageBox.Show(excp.Message);
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            if (searchTextBox.Text == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT ID,CustomerName,ItemName,Price,Quantity,Quantity*Price AS TotalCost FROM Orders WHERE CustomerName = '" + searchTextBox.Text + "' OR ItemName = '" + searchTextBox.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (isFill > 0)
            {
                showDataGridView.DataSource = "";
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                if (showDataGridView.DataSource == "")
                {
                    MessageBox.Show("There is no available data..");
                    return;
                    ;
                }
                MessageBox.Show("Sorry Not Found This Name..");
                return;
            }

        }

        private bool CheckIfNumeric(string input)
        {
            return input.IsNumeric();
        }

        private void Clear()
        {
            cNameComboBox.Text = "";
            iComboBox.Text = "";
            priceTextBox.Clear();
            quantityTextBox.Clear();
        }

        private int SelectCustomerName()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT CustomerName FROM Orders WHERE CustomerName = '" + cNameComboBox.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);


            if (isFill > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int ShowData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT ID,CustomerName,ItemName,Price,Quantity,Quantity*Price AS TotalCost FROM Orders";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (isFill > 0)
            {
                showDataGridView.DataSource = dataTable;
                return 1;
            }
            else
            {
                showDataGridView.DataSource = "";
                return 0;
            }
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            idTextBox.Text = showDataGridView[0, e.RowIndex].Value.ToString();
            cNameComboBox.Text = showDataGridView[1, e.RowIndex].Value.ToString();
            iComboBox.Text = showDataGridView[2, e.RowIndex].Value.ToString();
            priceTextBox.Text = showDataGridView[3, e.RowIndex].Value.ToString();
            quantityTextBox.Text = showDataGridView[4, e.RowIndex].Value.ToString();
        }
    }
}
