using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBaseConnectionPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\bk.accdb");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\bk.accdb");
            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zulup\Documents\Visual Studio 2012\Projects\CodeTimeDB\CodeTimeDB\bin\Debug\ClsDB.accdb;Persist Security Info=False
            //");

            OleDbCommand cmd = new OleDbCommand("Select * From bk", con);
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
           // dataGridView1.DataSource = table;

         //   dataGridView1.ReadOnly = true;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void empinsert_Click(object sender, EventArgs e)
        {
           // float salary = float.Parse( textBox3.Text);
            
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"Insert into bk(Field1) values('" + textBox1.Text + "')" ;        
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void empveiw_Click(object sender, EventArgs e)
        {

        }





        private void empupdate_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\bk.accdb");
            int a=21;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText =@"UPDATE bk SET Field1='" + textBox1.Text + "', WHERE Field2='"+a+"'";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            
            //OleDbCommand update = new OleDbCommand();
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }





        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void empdelete_Click(object sender, EventArgs e)
        {
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\bk.accdb";
           // string temptitle = textBox1.Text;
            con.Open();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM bk where Field1= ('" + textBox1.Text + "')", con);
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = 
            //cmd.Connection = con;
           
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
 