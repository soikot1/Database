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

namespace DataBase
{
    public partial class UpdateButton : Form
    {
        public UpdateButton()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        string connectionString = "Data Source=DESKTOP-95PC2MO;Initial Catalog=StudentDb;Integrated Security=True";
        private void button1_Click_1(object sender, EventArgs e)
        {
            string name =nameTextBox.Text;
            string address=addressTextBox.Text;
            string contactNo = contactTextBox.Text;
            string regNo= regNoTextBox.Text;
            int departmentId = Convert.ToInt32(departmentTextBox.Text);
            if(Exists(regNo))
            {
                MessageBox.Show("Already Exists");
                return;
            }

             
       
            
     
           SqlConnection sqlConnection=new SqlConnection(connectionString);
           string query = "INSERT INTO Students(Name,Address,ContactNo,RegNo,DepartmentId)VALUES('" + name + "','" + address + "','" + contactNo + "','" + regNo + "',"+departmentId+")";
           SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
           sqlConnection.Open();
           int isExecuted=sqlCommand.ExecuteNonQuery();
            if(isExecuted>0)
            {
                MessageBox.Show("Saved");
                
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            sqlConnection.Close();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = " SELECT*FROM view2";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
            
        }

        private void Update_Click(object sender, EventArgs e)
        {

            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string contactNo = contactTextBox.Text;
            string regNo = regNoTextBox.Text;
            int departmentId = Convert.ToInt32(departmentTextBox.Text);
            int id = Convert.ToInt32(idTextBox.Text);




            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "   UPDATE Students SET Name='" + name + "',Address='" + address + "',ContactNo='" + contactNo + "',RegNo='" + regNo + "',DepartmentId=" + departmentId + " WHERE ID=" + id + "";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                MessageBox.Show("Update");

            }
            else
            {
                MessageBox.Show("Not Update");
            }
            sqlConnection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextBox.Text);




            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "DELETE FROM Students   WHERE ID=" + id + "";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                MessageBox.Show("Delete");

            }
            else
            {
                MessageBox.Show("Not Delete ");
            }
            sqlConnection.Close();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextBox.Text);






            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = " SELECT*FROM view2 WHERE ID=" + id + "";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
        private bool Exists(string regNo)
        {
            bool isExists = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = " SELECT*FROM view2 WHERE RegNo='" + regNo + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            if(dataTable.Rows.Count>0)
            {
                isExists = true;
            }
            else
            {
                isExists = false;
            }
            sqlConnection.Close();
            return   isExists;
        }
        private void UpdateButton_Load(object sender, EventArgs e)
        {

        }
    }
}
