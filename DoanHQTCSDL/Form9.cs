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
    public partial class Form9 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form9()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from Phieunhap";
            ap.SelectCommand = command;
            table.Clear();
            ap.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Chitietphieunhap chitietphieunhap = new Chitietphieunhap();
            chitietphieunhap.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into Phieunhap values('" + textBox23.Text + "','" + textBox24.Text + "','" + textBox25.Text + "','" + dateTimePicker1.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox23.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox23.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox24.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox25.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.CustomFormat = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  Phieunhap where MaPN='" + textBox23.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update Phieunhap set MaNhanvien='" + textBox24.Text + "',MaNCC='" + textBox25.Text + "',Ngaynhap='" + dateTimePicker1.CustomFormat + "'  where MaPN= '" + textBox23.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }
    }
}
