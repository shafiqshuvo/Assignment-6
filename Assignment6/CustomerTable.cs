﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class CustomerTable : Form
    {
        public CustomerTable()
        {
            InitializeComponent();
        }

        private void AddData()
        {
            try
            {

                //Connection Establish
                string connectionString = @"Server=FATEMA; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Comand establish
                string commandString = @"INSERT INTO Customer_Table(Customer_Name, Contact_No) VALUES('" + customerNameTextBox.Text + "', '" + contactTextBox.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show(" Registration successfully.");
                }
                else
                {
                    MessageBox.Show("Information can't added!!!.");
                }

                sqlConnection.Close();


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ShowData()
        {
            try
            {
                //Connection Establish
                string connectionString = @"Server=FATEMA; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Comand establish
                string commandString = @"SELECT * FROM Customer_Table";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    customerDetailsDataGridView.DataSource = dataTable;
                }
                else
                {
                    customerDetailsDataGridView.DataSource = null;
                    MessageBox.Show("No data Found!!");
                }


                sqlConnection.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
           

        private void SearchData()
        {
            try
            {
                string connectionString = @"Server=FATEMA; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Comand establish
                string commandString = @"SELECT * FROM Customer_Table WHERE Customer_Name LIKE  '" + customerNameTextBox.Text +"%' ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    customerDetailsDataGridView.DataSource = dataTable;
                }
                else
                {
                    customerDetailsDataGridView.DataSource = null;
                    MessageBox.Show("No data Found!!");
                }

                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
          
        }

        private void DeleteData()
        {
            try
            {
                string connectionString = @"Server=FATEMA; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Comand establish
                string commandString = @"DELETE FROM Customer_Table WHERE  Customer_Name LIKE '" + customerNameTextBox.Text + "%' ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Name is deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Name can't be deleted !!!.");
                }

                sqlConnection.Close();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void UpdateData()
        {
            try
            {
                string connectionString = @"Server=FATEMA; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command establish
                string commandString = @"UPDATE Customer_Table SET Customer_Name = '" + customerNameTextBox.Text + "',  Contact_No = '" + contactTextBox.Text + "' WHERE Customer_Id= " + customerIdTextBox.Text + " ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Update Successful");
                }

                else
                {
                    MessageBox.Show("Ivalid Update!!");
                }

                sqlConnection.Close();

            }

            catch (Exception exception)

            {
                MessageBox.Show(exception.Message);
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            AddData();
            ShowData();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchData();
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateData();
            ShowData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteData();
            ShowData();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            OrderTable orderTable = new OrderTable();
            this.Hide();
            orderTable.ShowDialog();
            this.Show();
        }
    }
}
