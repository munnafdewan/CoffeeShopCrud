using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MyWindowsFormsApp.BLL;

namespace MyWindowsFormsApp
{
    public partial class CustomerCrud : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerCrud()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Phone Number can not be Empty!!");
                return;
            }

            //Unique
            if (_customerManager.IsNameExist(nameTextBox.Text,phoneTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exist!!");
                return;
            }

            //Add/Insert
            if (_customerManager.Add(nameTextBox.Text,phoneTextBox.Text, addressTextBox.Text))
            {
                MessageBox.Show("Saved Data");
                Clear();
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _customerManager.Display();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();

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
            if (_customerManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _customerManager.Display();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            if (_customerManager.Update(nameTextBox.Text, phoneTextBox.Text,addressTextBox.Text, Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
               
                showDataGridView.DataSource = _customerManager.Display();
                Clear();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
            showDataGridView.DataSource = _customerManager.Display();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Search(nameTextBox.Text);
        }

        private void Clear()
        {
            nameTextBox.Clear();
            phoneTextBox.Clear();
            addressTextBox.Clear();
        }
    }
}
