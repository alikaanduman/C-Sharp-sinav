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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public OleDbDataReader dtr;
        public OleDbConnection con;
        public OleDbDataAdapter data;
        public BindingSource bs;
        public BindingSource bs1;
        public OleDbCommandBuilder c;
        public DataTable dt;
     //   public DataTable dt1;

        public OleDbCommand com;
        
        public string yol, sorgu,cins,uyruks,uyeler;
   private void baglan()
        {
            yol = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|osym.accdb";
            con = new OleDbConnection(yol);
            con.Open();
       }
        private void Form2_Load(object sender, EventArgs e)
        {
            baglan();
            doldur("select*from uyeler");
            combodoldur();
            textdoldur();

            comboBox1.Items.Add("Bursa");
            comboBox1.Items.Add("Konya");
            comboBox1.Items.Add("Hakkari");
            comboBox1.Items.Add("Diyarbekir");
            comboBox1.Items.Add("Adana");


        }


        private void textdoldur()
        {
            doldur("select*from uyeler");

           if (dt.Rows.Count>0)
            {
                textBox1.DataBindings.Clear();
                textBox2.DataBindings.Clear();
                textBox3.DataBindings.Clear();
                textBox4.DataBindings.Clear();
                textBox5.DataBindings.Clear();
                textBox6.DataBindings.Clear();
                comboBox1.DataBindings.Clear();
                comboBox2.DataBindings.Clear();
                dateTimePicker1.DataBindings.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;

            }

          //  textBox7.DataBindings.Add("text", bs, "sn");
            textBox1.DataBindings.Add("text", bs, "tc");
            textBox2.DataBindings.Add("text", bs, "sifre");
            textBox3.DataBindings.Add("text", bs, "ad");
            textBox4.DataBindings.Add("text", bs, "soy");
            textBox5.DataBindings.Add("text", bs, "baba");
            textBox6.DataBindings.Add("text", bs, "anne");
            dateTimePicker1.DataBindings.Add("text", bs, "dt");
            comboBox1.DataBindings.Add("text", bs, "dyer");
            comboBox2.DataBindings.Add("text", bs, "il");
            comboBox3.DataBindings.Add("text", bs, "ilce");
            doldur("select*from uyeler");
           cins = dt.Rows[bs.Position]["cin"].ToString();
            if (cins=="Kadın")
            {
                radioButton1.Checked = true;
            }
            else if (cins=="Erkek")
            {
                radioButton2.Checked = true;
            }

           uyruks = dt.Rows[bs.Position]["uyruk"].ToString();
            if (uyruks=="TC")
            {
                checkBox1.Checked = true;

            }
            else if (uyruks=="DİĞER")
            {
                checkBox2.Checked = true;
            }


        }

      private void doldur(string sorgu1)
      {
          data=new OleDbDataAdapter (sorgu1,con);
          dt=new DataTable();
          data.Fill(dt);
          bs=new BindingSource();
          bs.DataSource=dt;
          
      
      
      }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
        
        
            if (radioButton1.Checked==true)
	{
		 cins="Kadın";
	}
         else if (radioButton2.Checked==true)
	{
		 cins="Erkek";

	}
          
            if (checkBox1.Checked==true)
	{
		 uyruks="TC";

	}else if(  checkBox2.Checked==true )
	{
              uyruks="DİĞER";
	}
            
            
            
            
            sorgu="insert into uyeler(tc,sifre,ad,soy,baba,anne,dt,dyer,il,ilce,cin,uyruk)VALUES('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+dateTimePicker1.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"','"+comboBox3.Text+"','"+cins+"','"+uyruks+"')";
                com=new OleDbCommand(sorgu,con);
            com.ExecuteNonQuery();
            doldur("select*from uyeler");
        }

       
        
        
        private void combodoldur()
        {
            doldur("select*from il");
            foreach (DataRow ss in dt.Rows)
            {
                comboBox2.Items.Add(ss["il"].ToString());
            }
          
   
        
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox3.Items.Clear();

            doldur("select*from ilce where il='" + comboBox2.Text + "'");
            foreach (DataRow ss in dt.Rows)
            {
                comboBox3.Items.Add(ss["ilce"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
           // doldur("select*from uyeler");
           doldur("select*from uyeler where tc=" + textBox1.Text + "'");
          cins = dt.Rows[bs1.Position]["cin"].ToString();
            if (cins == "Kadın")
            {
                radioButton1.Checked = true;

            }
            else if (cins == "Erkek")
            {
                radioButton2.Checked = true;


            }
           uyruks = dt.Rows[bs.Position]["uyruk"].ToString();
            if (uyruks == "TC")
            {
                checkBox1.Checked = true;

            }
            else if (uyruks == "DİĞER")
            {
                checkBox2.Checked = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            //doldur("select*from uyeler");
          doldur("select*from uyeler where tc="+textBox1.Text+"'");
            cins=dt.Rows[bs1.Position]["cin"].ToString();
         if (cins=="Kadın")
          {
            radioButton1.Checked=true;
            
            }else if (cins=="Erkek")
            {
            radioButton2.Checked=true;

            
            }
             uyruks=dt.Rows[bs.Position]["uyruk"].ToString();  
            if (uyruks=="TC")
            {
                checkBox1.Checked = true;

            }
            else if (uyruks=="DİĞER")
            {
                checkBox2.Checked = true;
            }
            
            
	{
		 
	}
	{
		 
	}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sorgu = "UPDATE uyeler SET tc='"  +textBox1.Text+"' WHERE uyeler.sifre="+textBox2.Text+"";
            com = new OleDbCommand(sorgu, con);
            com.ExecuteNonQuery();
        }
    }
}
