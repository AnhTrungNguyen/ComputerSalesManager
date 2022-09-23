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
    public partial class Form8 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form8()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from NhanVien";
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

        private void Form8_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into NhanVien values('" + textBox20.Text + "','" + textBox21.Text + "','" + textBox22.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox20.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox20.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox21.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox22.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  NhanVien where MaNhanvien='" + textBox20.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update NhaSanXuat set HotenNV='" + textBox21.Text + "',DienthoaiNV='" + textBox22.Text + "'  where MaNhanVien= '" + textBox20.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }
    }
}
