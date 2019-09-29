using System;
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
    public partial class Form1 : Form
    {
        public Form1()
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
                string commandString = @"INSERT INTO Item_Table (Item_Name, Item_Price) VALUES( '"+ itemNameTextBox.Text + " ', " + itemPriceTextBox.Text + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Item is added successfully.");
                }
                else
                {
                    MessageBox.Show("Item can't added!!!.");
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
                string commandString = @"SELECT * FROM Item_Table";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    showDataGridView.DataSource = null;
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
                string commandString = @"SELECT * FROM Item_Table WHERE Item_Id  = " + itemIdTextBox.Text + " ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    showDataGridView.DataSource = null;
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
            string connectionString = @"Server=FATEMA; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Comand establish
            string commandString = @"DELETE FROM Item_Table WHERE  Item_Id = " + itemIdTextBox.Text + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


            sqlConnection.Open();

            //Sql command Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                MessageBox.Show("Item is deleted successfully.");
            }
            else
            {
                MessageBox.Show("Item can't delete !!!.");
            }

            sqlConnection.Close();
        }

        private void UpdateData()
        {
            try
            {
                string connectionString = @"Server=FATEMA; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command establish
                string commandString = @"UPDATE Item_Table SET Item_Name = '" + itemNameTextBox.Text + "',  Item_Price = " + itemPriceTextBox.Text + "  WHERE Item_Id = " + itemIdTextBox.Text + " ";
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteData();
            ShowData();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateData();
            ShowData();
           
        }

        private void customerDetailsButton_Click(object sender, EventArgs e)
        {
            CustomerTable customerTable = new CustomerTable();
            this.Hide();
            customerTable.ShowDialog();
            this.Show();
            
        }
    }
}

