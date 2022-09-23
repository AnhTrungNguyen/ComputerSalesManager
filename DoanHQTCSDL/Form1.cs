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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = label2.Text;
                string mk = label3.Text;
                string sql = "select * from Dangnhap where TaiKhoan='" + textBox1.Text + "' and MatKhau='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    MessageBox.Show("Dang nhap thanh cong");
                    Form11 form11 = new Form11();
                    form11.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Dang nhap that bai");
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Ban co muon thoat khong ? ", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form18 form18 = new Form18();
            form18.Show();
            this.Hide();
        }
    }
}
