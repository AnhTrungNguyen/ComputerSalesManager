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
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form4()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from NhaCungCap";
            ap.SelectCommand = command;
            table.Clear();
            ap.Fill(table);
            dgvNhacungcap.DataSource = table;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into NhaCungCap values('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','"+textBox7.Text+"')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void dgvNhacungcap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.ReadOnly = true;
            int i;
            i = dgvNhacungcap.CurrentRow.Index;
            textBox4.Text = dgvNhacungcap.Rows[i].Cells[0].Value.ToString();
            textBox5.Text = dgvNhacungcap.Rows[i].Cells[1].Value.ToString();
            textBox6.Text = dgvNhacungcap.Rows[i].Cells[2].Value.ToString();
            textBox7.Text = dgvNhacungcap.Rows[i].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  NhaCungCap where MaNCC='" + textBox4.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update NhaSanXuat set TenNCC='" + textBox5.Text + "',DiachiNCC='" + textBox6.Text + "',DienthoaiNCC='"+textBox7+ "'  where MaNCC= '" + textBox4.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }
    }
}
