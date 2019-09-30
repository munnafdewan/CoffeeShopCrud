using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using MyWindowsFormsApp.BLL;

namespace MyWindowsFormsApp.Repository
{
    public class CustomerRepository
    {
        public bool Add(string name, string phone,string address)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Customers (Name, Phone, Address) Values ('" + name + "', '" + phone + "','"+address+"')";
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
            string commandString = @"SELECT * FROM Customers";
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

        public bool Update(string name, string phone,string address, int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE Customers SET Name =  '" + name + "' , Phone = '" + phone + "' , Address = '" + address + "' WHERE ID = " + id + "";
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

        public bool Delete(int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //DELETE FROM Items WHERE ID = 3
                string commandString = @"DELETE FROM Customers WHERE ID = " + id + "";
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
                string commandString = @"SELECT * FROM Customers WHERE Name='" + name + "'";
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

        public bool IsNameExist(string name,string phone)
        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customers WHERE Name='" + name + "','"+phone+"'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return isExist;
        }
    }
  
}
