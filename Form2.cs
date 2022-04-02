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
using System.Configuration;
namespace projet
{
    public partial class Form2 : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-N8SA1K2\SQLEXPRESS;Initial Catalog=dbp;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader Reader;
        DataTable table = new DataTable();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Remplirgrid();
        }
        public void Remplirgrid()
        {
            Deconnecter();
            cnx.Open();
            //result = new Collection<string[]>();
            cmd = new SqlCommand("select * form users where role='1'", cnx);

            Reader = cmd.ExecuteReader();
            table.Load(Reader);
            //dataGridView1.DataSource = table;
            if(Reader.HasRows)
            {
                while (Reader.Read())
                {
                    MessageBox.Show(Reader.GetString(0), "Attention",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows.Add(Reader.GetString(0), Reader.GetString(1), Reader.GetString(3), Reader.GetString(4), Reader.GetString(5), Reader.GetString(6), Reader.GetString(7), Reader.GetString(8),Reader.GetString(9),Reader.GetString(10),Reader.GetString(11),Reader.GetString(12),Reader.GetString(13),Reader.GetString(14),Reader.GetString(15));
                }
            }
            cnx.Close();
        }
        public void Deconnecter()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}

