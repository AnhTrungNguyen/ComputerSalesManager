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
    public partial class Form6 : Form
    {
        SqlConnection con;
        SqlCommand command;
        string str = @"Data Source=TRUNG\SQLEXPRESS;Initial Catalog=QLBMT;Integrated Security=True";
        SqlDataAdapter ap = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form6()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            command = con.CreateCommand();
            command.CommandText = "select * from LoaiThietBi";
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

        private void Form6_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "insert into LoaiThietbi values('" + textBox14.Text + "','" + textBox15.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox14.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox15.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "delete from  LoaiThietbi where Maloai='" + textBox14.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            command = con.CreateCommand();
            command.CommandText = "update LoaiThietbi set Tenloai='" + textBox15.Text + "' where Maloai= '"+textBox14.Text+"'";
            command.ExecuteNonQuery();
            loadData();
        }
    }
}
