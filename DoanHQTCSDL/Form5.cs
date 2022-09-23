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
    
    public partial class Form5 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form5()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from ThietBi";
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

        private void Form5_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into ThietBi values('" + textBox8.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+textBox4.Text+"','"+textBox5.Text+"')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox8.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  ThietBi where Mathietbi='" + textBox8.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update ThietBi set TenThietbi='" + textBox1.Text + "',MaNSX='" + textBox2.Text + "',Maloai='" + textBox3 + "',Giathanh='"+textBox4.Text+"',MaNCC='"+textBox5.Text+ "' where Mathietbi='" + textBox8.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        
    }
}
