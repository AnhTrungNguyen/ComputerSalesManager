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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True");
            conn.Open();
            String Sqldangki = "insert into Dangnhap values ('" + textBox1.Text + "' ,'" + textBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(Sqldangki, conn);
            SqlDataReader data = cmd.ExecuteReader();
            MessageBox.Show("Dang ki thanh cong");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True");
            conn.Open();
            String Sqldangki = "update Dangnhap set MatKhau='" + textBox2.Text + "' where TaiKhoan='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(Sqldangki, conn);
            SqlDataReader data = cmd.ExecuteReader();
            MessageBox.Show("Sua thanh cong");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True");
            conn.Open();
            String Sqldangki = "delete from  Dangnhap where TaiKhoan='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(Sqldangki, conn);
            SqlDataReader data = cmd.ExecuteReader();
            MessageBox.Show("Xoa thanh cong");
        }
    }
}
