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
    public partial class Form16 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form16()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from LoaiThietbi";
            ap.SelectCommand = command;
            table.Clear();
            ap.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
            this.Hide();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqlSearch = "select * from LoaiThietbi where Tenloai like '%" + textBox15.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlSearch, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sqlSearch = "execute sp_TBtheoLOAI 'LOAI1'";
            SqlCommand cmd = new SqlCommand(sqlSearch, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
