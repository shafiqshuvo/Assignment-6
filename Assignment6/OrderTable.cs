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
    public partial class OrderTable : Form
    {
        public OrderTable()
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
                string commandString = @"INSERT INTO Order_Table (Item_Name, Quantity ) VALUES( '" + itemNameTextBox.Text + "', " + quantityTextBox.Text + ")";
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
                string commandString = @"SELECT * FROM Order_Table";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    showOrderGridView.DataSource = dataTable;
                }
                else
                {
                    showOrderGridView.DataSource = null;
                    MessageBox.Show("No data Found!!");
                }


                sqlConnection.Close();
            }
            catch (Exception exception)
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

                //string commandString = @"SELECT * FROM Order_Table WHERE ID  = " + nameSearchTextBox.Text + " ";
                /*string commandString = @"SELECT Customer_Name, Item_Name, Price  FROM Order_Table
                JOIN Customer_Table ON Order_Table.Customer_Id = Customer_Table.Customer_Id 
                JOIN Item_Table ON Order_Table.Item_Id = Item_Table.Item_Id  WHERE Customer_Name  =  '" + nameSearchTextBox.Text + "' ";*/

                string commandString = @"SELECT * FROM Order_Table WHERE Customer_Id  = " + idSearchTextBox.Text + " ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    showOrderGridView.DataSource = dataTable;
                }
                else
                {
                    showOrderGridView.DataSource = null;
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
                string commandString = @"DELETE FROM Order_Table WHERE Customer_Id = " + idSearchTextBox.Text + " ";
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
                string commandString = @"UPDATE Order_Table SET  Quantity = " + quantityTextBox.Text + " , Item_Name = '" + itemNameTextBox.Text + "' WHERE Customer_Id = " + customerIdTextBox.Text + " ";               SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


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

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                
            string connectionString = @"Server=FATEMA; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT Customer_Name, Item_Price, Total_price = (Item_Price * Quantity), Contact_No 
            FROM Order_Table JOIN Customer_Table ON Order_Table.Customer_Id = Customer_Table.Customer_Id 
            JOIN Item_Table ON Order_Table.Item_Name = Item_Table.Item_Name WHERE Customer_Name  =  '" + nameSearchBox.Text + "' ";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


            sqlConnection.Open();

            //Sql command Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                showOrderGridView.DataSource = dataTable;
            }
            else
            {
                showOrderGridView.DataSource = null;
                MessageBox.Show("No data Found!!");
            }

            sqlConnection.Close();

            }


            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}

