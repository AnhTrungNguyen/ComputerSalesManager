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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = label2.Text;
                string sql = "select * from Dangnhap where MatKhau='"+textBox1.Text+"' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    MessageBox.Show("Dang nhap thanh cong");
                    Form3 form3 = new Form3();
                    form3.Show();
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
    }
}
