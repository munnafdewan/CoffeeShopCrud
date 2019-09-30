using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyWindowsFormsApp.BLL;

using System.Threading.Tasks;

namespace MyWindowsFormsApp.Repository
{
    public class OrderRepository
    {

        public bool Add(string itemName,string price)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Orders (ItemName,Price) Values ('" +itemName+ "','"+price+"')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return isAdded;

        }

        public DataTable Display()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Orders";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //if (dataTable.Rows.Count > 0)
            //{
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();

            return dataTable;

        }

        public bool Delete(int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //DELETE FROM Items WHERE ID = 3
                string commandString = @"DELETE FROM Orders WHERE ID = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Delete
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return false;
        }

        public bool Update(string name, string price, int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE Orders SET ItemName =  '" + name + "' , Price = " + price + " WHERE ID = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return false;
        }

        public DataTable Search(string name)
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server = DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Orders WHERE ItemName='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                //if (dataTable.Rows.Count > 0)
                //{
                //    //showDataGridView.DataSource = dataTable;
                //}
                //else
                //{
                //    //MessageBox.Show("No Data Found");
                //}

                ////Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                // MessageBox.Show(exeption.Message);
            }

            return dataTable;
        }
    }
}
