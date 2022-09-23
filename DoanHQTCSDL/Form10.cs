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
    public partial class Form10 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form10()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from Phieuxuat";
            ap.SelectCommand = command;
            table.Clear();
            ap.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            chitietphieuxuat chitietphieuxuat = new chitietphieuxuat();
            chitietphieuxuat.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into Phieuxuat values('" + textBox26.Text + "','" + textBox27.Text + "','" + textBox28.Text + "','" + dateTimePicker2.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox26.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox26.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox27.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox28.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dateTimePicker2.CustomFormat = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  Phieuxuat where MaPX='" + textBox26.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update Phieuxuat set MaNhanvien='" + textBox27.Text + "',MaKhachhang='" + textBox28.Text + "',Ngayxuat='" + dateTimePicker2.CustomFormat + "' where MaPX= '" + textBox26.Text + "' ";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sqlSearch = "select * from f_dsbh2020()";
            SqlCommand cmd = new SqlCommand(sqlSearch, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
