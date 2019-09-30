using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;

namespace MyWindowsFormsApp
{
    public partial class OrderCrud : Form
    {
        OrderManager _orderManager = new OrderManager();
        public OrderCrud()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string price = "";
            decimal black = 120;
            decimal cold = 100;
            decimal hot = 90;
            decimal regular = 80;
        

            if (itemComboBox.Text == "Black")
            {
                price = (black * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Cold")
            {
                price = (cold * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Hot")
            {
                price = (hot * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Regular")
            {
                price = (regular * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Spacial")
            {
                price = (regular * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            //Mandatory

            //Unique
            //if (_orderManager.IsNameExist(nameTextBox.Text))
            //{
            //    MessageBox.Show(nameTextBox.Text + " Already Exist!!");
            //    return;
            //}

            //Add/Insert
            if (_orderManager.Add(itemComboBox.Text,price))
            {
                MessageBox.Show("Data Saved");
                Clear();
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            //showDataGridView.DataSource = dataTable;
           showDataGridView.DataSource = _orderManager.Display();

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_orderManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _orderManager.Display();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string price = "";
            decimal black = 120;
            decimal cold = 100;
            decimal hot = 90;
            decimal regular = 80;
            int id;

            if (itemComboBox.Text == "Black")
            {
                price = (black * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Cold")
            {
                price = (cold * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Hot")
            {
                price = (hot * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Regular")
            {
                price = (regular * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Spacial")
            {
                price = (regular * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            //Mandatory

            //Unique
            //if (_orderManager.IsNameExist(nameTextBox.Text))
            //{
            //    MessageBox.Show(nameTextBox.Text + " Already Exist!!");
            //    return;
            //}

            //Add/Insert
            if (_orderManager.Update(itemComboBox.Text, price,Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Data Updated");
                Clear();
            }
            else
            {
                MessageBox.Show("Data Not Updated");
            }
           // showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _orderManager.Display();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Search(itemComboBox.Text);
        }

        private void Clear()
        {
            
            quantityTextBox.Clear();
       
        }
    }
}
