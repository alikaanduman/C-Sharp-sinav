using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Ali_Kaan_Duman_15491
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public OleDbDataReader dtr2;
        public OleDbConnection con;
        public OleDbDataAdapter data;
        public BindingSource bs;
        public OleDbCommandBuilder c;
        public DataTable dt1;
        public OleDbCommand com;
        public OleDbException e;
        public string yol, sorgu;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void baglan()
        {
            yol = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|osym.accdb";
            con = new OleDbConnection(yol);
            con.Open();
        
        
        }


        private void doldur(string sorgu1)
        {
            data = new OleDbDataAdapter(sorgu1, con);
            dt1 = new DataTable();
            data.Fill(dt1);
            bs = new BindingSource();
            bs.DataSource = dt1;



        }
        


        private void button1_Click(object sender, EventArgs e)
        {

          /*  Form2 f2 = new Form2();
           f2.Show();*/
            
            
              com = new OleDbCommand(sorgu,con);
             // dtr2= com.ExecuteReader();
              com.Connection = con;
              doldur(" select * from uyeler");            
              com.CommandText = "'Select * from sifre where tc='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
           
            if (textBox1.Text=="1")
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
	{
                MessageBox.Show("HATALI BİR GİRİŞ YAPTINIZ LÜTFEN TEKRAR DENEYİNİZ");
	}
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
                
            baglan();
        }
    }
}
