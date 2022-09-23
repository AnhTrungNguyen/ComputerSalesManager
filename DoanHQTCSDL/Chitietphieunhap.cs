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
    public partial class Chitietphieunhap : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Chitietphieunhap()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from Chitietphieunhap";
            ap.SelectCommand = command;
            table.Clear();
            ap.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Chitietphieunhap_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into Chitietphieunhap values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  Chitietphieunhap where MaPN='" + textBox1.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update Chitietphieunhap set MaThietbi='" + textBox2.Text + "',Soluongnhap='" + textBox3.Text + "',Dongianhap='" + textBox4.Text + "'  where MaPN= '" + textBox1.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String sqlSearch = "select * from f_tbnnn()";
            SqlCommand cmd = new SqlCommand(sqlSearch, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
