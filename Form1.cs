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
    public partial class Form1 : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-N8SA1K2\SQLEXPRESS;Initial Catalog=dbp;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader Reader;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
        this.Hide();
        Form2 admin = new Form2();
        Form3 agent = new Form3();
        Form4 employe = new Form4();


        Deconnecter();
        cnx.Open();

            cmd = new SqlCommand("select role from users where login='" + login.Text + "'", cnx);

        Reader = cmd.ExecuteReader();
            Reader.Read();
            string x = Convert.ToString(Reader["role"]);


        cnx.Close();
            if (x == "1")
            {
                admin.Show();
            }
            else if (x == "2")
            {
                agent.Show();
            }
            else if (x == "3")
{
    employe.Show();
}
        }
            
     
        public void Deconnecter()//ay bd ma7loula tssakerha//
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}
