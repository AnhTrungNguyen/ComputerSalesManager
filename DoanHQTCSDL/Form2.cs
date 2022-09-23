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

namespace DoanHQTCSDL
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }
        public void loadData1()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from NhaSanXuat";
            ap.SelectCommand = command;
            table.Clear();
            ap.Fill(table);
            dataGridView1.DataSource = table;
           
        }

       
        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData1();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into NhaSanXuat values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            command.ExecuteNonQuery();
            loadData1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  NhaSanXuat where MaNSX='"+textBox1.Text+"'";
            command.ExecuteNonQuery();
            loadData1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update NhaSanXuat set TenNSX='" + textBox2.Text + "',Quocgia='" + textBox3.Text + "' where MaNSX= '" + textBox1.Text + "' ";
            command.ExecuteNonQuery();
            loadData1();
        }
    }
}
