using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentData();
            deleteButton.Enabled = false;
            editButton.Enabled = false;
        }

        private void GetStudentData()
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HER71UT;Initial Catalog=LabTask;Integrated Security=True");
         //   var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentData", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HER71UT;Initial Catalog=LabTask;Integrated Security=True");
            //var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into StudentData values (@RegistrationNo, @Name, @Department, @Session, @CGPA, @Address)", con);
            cmd.Parameters.AddWithValue("@RegistrationNo", regNoBox.Text);
            cmd.Parameters.AddWithValue("@Name", nameBox.Text);
            cmd.Parameters.AddWithValue("@Department", deptBox.Text);
            cmd.Parameters.AddWithValue("@Session", int.Parse(sessionBox.Text));
            cmd.Parameters.AddWithValue("@CGPA", double.Parse(cgpaBox.Text));
            cmd.Parameters.AddWithValue("@Address", addressBox.Text);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Successfully saved");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            regNoBox.Clear();
            nameBox.Clear();
            deptBox.Clear();
            sessionBox.Clear();
            cgpaBox.Clear();
            addressBox.Clear();
            regNoBox.Focus();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            regNoBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nameBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            deptBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            sessionBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cgpaBox.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            addressBox.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HER71UT;Initial Catalog=LabTask;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UPDATE StudentData SET RegistrationNo=@RegistrationNo, Name=@Name, Department=@Department,Session=@Session, CGPA=@CGPA WHERE RegistrationNo=@RegistrationNo", con);
            cmd.Parameters.AddWithValue("@RegistrationNo", regNoBox.Text);
            cmd.Parameters.AddWithValue("@Name", nameBox.Text);
            cmd.Parameters.AddWithValue("@Department", deptBox.Text);
            cmd.Parameters.AddWithValue("@Session", int.Parse(sessionBox.Text));
            cmd.Parameters.AddWithValue("@CGPA", double.Parse(cgpaBox.Text));
            cmd.Parameters.AddWithValue("@Address", addressBox.Text);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HER71UT;Initial Catalog=LabTask;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("DELETE FROM StudentData WHERE RegistrationNo=@RegistrationNo", con);
            cmd.Parameters.AddWithValue("@RegistrationNo", regNoBox.Text);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            
            deleteButton.Enabled = true;
            editButton.Enabled = true;
            //string reg = searchBox.Text;
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-HER71UT;Initial Catalog=LabTask;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from StudentData Where RegistrationNo = '"+ textBox1.Text+ "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(""))
            {
                deleteButton.Enabled = false;
                editButton.Enabled = false;
            }
        }
    }
}
