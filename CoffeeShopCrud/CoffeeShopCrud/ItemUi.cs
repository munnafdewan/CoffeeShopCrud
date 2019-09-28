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
    public partial class ItemUi : Form
    {
        string connectionString = @"Server = DESKTOP-J6257UA; Database = CoffeeShop; Integrated Security = true";

        int id;
        public ItemUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string price = priceTextBox.Text;

            if (name == "" || price == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            else if (CheckIfNumeric(name))
            {
                MessageBox.Show("Please enter Item name, not numeric value.");
                nameTextBox.Clear();
                return;
            }
            if (SelectName() == 1)
            {
                MessageBox.Show("Item Name is Already exist..");
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "INSERT INTO Items(Name, Price)VALUES('" + name + "', " + price + ")";
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

        private void Clear()
        {
            nameTextBox.Clear();
            priceTextBox.Clear();
        }

        private bool CheckIfNumeric(string input)
        {
            return input.IsNumeric();
        }

        private int SelectName()
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT Name FROM Items WHERE Name = '" + nameTextBox.Text + "'";
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

        private void showButton_Click(object sender, EventArgs e)
        {
            if (ShowData() == 0)
            {
                showDataGridView.DataSource = "";
                MessageBox.Show("There is no available data");
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            string name = nameTextBox.Text;
            string price = priceTextBox.Text;

            if (name == "" || price == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            else if (CheckIfNumeric(name))
            {
                MessageBox.Show("Please enter Item name, not numeric value.");
                nameTextBox.Clear();
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "UPDATE Items SET Name = '" + nameTextBox.Text + "', Price = " + priceTextBox.Text + " WHERE ID = " + idTextBox.Text + "";
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
            //int id = Convert.ToInt32(showDataGridView[0, e.RowIndex].Value);
            if (idTextBox.Text == "")
            {
                MessageBox.Show("Please Select Id Field..");
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "DELETE FROM Items WHERE ID = " + idTextBox.Text + "";
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
                    MessageBox.Show("Please,,Select Correct ID Or Check Data available or not");
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
            string commandString = @"SELECT * FROM Items WHERE Name = '" + searchTextBox.Text + "'";
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
                MessageBox.Show("Sorry Not Found This Name..");
            }

        }
        private int ShowData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT * FROM Items";
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
            nameTextBox.Text = showDataGridView[1, e.RowIndex].Value.ToString();
            priceTextBox.Text = showDataGridView[2, e.RowIndex].Value.ToString();
            id = Convert.ToInt32(showDataGridView[0, e.RowIndex].Value);
        }

        
    }

    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
    }
}


