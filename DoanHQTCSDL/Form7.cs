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

namespace DoanHQTCSDL
{
    public partial class Form7 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form7()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from Khachhang";
            ap.SelectCommand = command;
            table.Clear();
            ap.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into Khachhang values('" + textBox16.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox16.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox16.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  Khachhang where MaKhachhang='" + textBox16.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update Khachhang set Tenkhachang='" + textBox1.Text + "',DiachiKH='" + textBox2.Text + "',DienthoaiKH='" + textBox3.Text + "'  where MaKhachhang= '" + textBox16.Text + "' ";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sqlSearch = "execute P_kh";
            SqlCommand cmd = new SqlCommand(sqlSearch, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
