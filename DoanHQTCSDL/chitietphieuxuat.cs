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
    public partial class chitietphieuxuat : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public chitietphieuxuat()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from Chitietphieuxuat";
            ap.SelectCommand = command;
            table.Clear();
            ap.Fill(table);
            dataGridView1.DataSource = table;
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

        private void chitietphieuxuat_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into Chitietphieuxuat values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  Chitietphieuxuat where MaPX='" + textBox1.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update Chitietphieuxuat set MaThietbi='" + textBox2.Text + "',Soluongxuat='" + textBox3.Text + "',Dongiaxuat='" + textBox4.Text + "' where MaPX= '" + textBox1.Text + "' ";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String sqlSearch = "select * from f_tbxnn()";
            SqlCommand cmd = new SqlCommand(sqlSearch, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
