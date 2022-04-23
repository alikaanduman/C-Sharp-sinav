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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
         public OleDbDataReader dtr;
        public OleDbConnection con;
        public OleDbDataAdapter data;
        public BindingSource bs;
        public OleDbCommandBuilder c;
        public DataTable dt;
        public OleDbCommand com;
        public string yol, sorgu,cin,uyruk;


         private void baglan()
        {
            yol = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|osym.accdb";
            con = new OleDbConnection(yol);
            con.Open();
       }
        private void Form3_Load(object sender, EventArgs e)
        {
            baglan();
            doldur1("select*from uyeler");
        }

             private void doldur1(string sorgu2)
             {
               data=new OleDbDataAdapter (sorgu2,con);
          dt=new DataTable();
          data.Fill(dt);
          bs=new BindingSource();
          bs.DataSource=dt;
          dataGridView1.DataSource=dt;
             }

             private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
             {

             }
    }
    
        }
    

