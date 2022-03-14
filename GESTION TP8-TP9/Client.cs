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

namespace GESTION_TP8_TP9
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        string str;
        SqlConnection cnx;
        private void Client_Load(object sender, EventArgs e)
        {
            str = @"Data Source=DESKTOP-A7ECOHN\SQLEXPRESS;Initial Catalog=GESTION;Integrated Security=True";
            cnx = new SqlConnection(str);


            dataGridView1.Columns.Add("IdProduit", "IdProduit");
            dataGridView1.Columns.Add("nomProduit", "nomProduit");
            dataGridView1.Columns.Add("prixProduit", "prixProduit");

            comboBox1.Items.Add("Tout");
            comboBox1.Items.Add("Commencent par");
            comboBox1.Items.Add("Ne commencent pas par");
            comboBox1.Items.Add("Se terminent par");
            comboBox1.Items.Add("Ne se terminent pas par");
            comboBox1.Items.Add("Contiennent");
            comboBox1.Items.Add("Ne Contiennent pas");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        string req;
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cnx.Open();
            if (comboBox1.SelectedItem.ToString() == "Tout")
                req = "select * from client ";



            if (comboBox1.SelectedItem.ToString() == "Commencent par")
                req = "select * from client where nomClient like '" + textBox1.Text + "%'";



            if (comboBox1.SelectedItem.ToString() == "Ne commencent pas par")
                req = "select * from client where nomClient not like '" + textBox1.Text + "%'";



            if ((comboBox1.SelectedItem.ToString() == "Se terminent par"))
                req = "select * from client where nomClient like '%" + textBox1.Text + "'";



            if ((comboBox1.SelectedItem.ToString() == "Ne se terminent pas par"))
                req = "select * from client where nomClient not like '%" + textBox1.Text + "'";



            if ((comboBox1.SelectedItem.ToString() == "Contiennent"))
                req = "select * from client where nomClient like '%" + textBox1.Text + "%'";



            if ((comboBox1.SelectedItem.ToString() == "Ne Contiennent pas"))
                req = "select * from client where nomClient not like '%" + textBox1.Text + "%'";



            SqlCommand cmd = new SqlCommand(req, cnx);


            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r[0], r[1], r[2]);
                
            }
            r.Close();
            cnx.Close();

            
            
        }
    }
}


//private void button1_Click(object sender, EventArgs e)
//{
//dataGridView1.DataSource = null;
//f.sc.Open();
//if(comboBox1.SelectedItem.ToString() =="tout")
//req = "select * from client ";



//if (comboBox1.SelectedItem.ToString() == "commencent par")
//req = "select * from client where nomClient like '" + textBox1.Text + "%'";



//if (comboBox1.SelectedItem.ToString() == "Ne commencent pas par")
//req = "select * from client where nomClient not like '" + textBox1.Text + "%'";



//if((comboBox1.SelectedItem.ToString() == "se termine par"))
//req = "select * from client where nomClient like '%" + textBox1.Text + "'";



//if ((comboBox1.SelectedItem.ToString() == "Ne se termine pas par"))
//req = "select * from client where nomClient not like '%" + textBox1.Text + "'";



//if ((comboBox1.SelectedItem.ToString() == "contient"))
//req = "select * from client where nomClient like '%"+textBox1.Text +"%'" ;



//if ((comboBox1.SelectedItem.ToString() == "ne contient pas"))
//req = "select * from client where nomClient not like '%" + textBox1.Text + "%'";


////affichage f table
//cmd = new SqlCommand(req, f.sc);
//dr = cmd.ExecuteReader();
//DataTable dt = new DataTable();
//dt.Load(dr);

//dataGridView1.DataSource = dt;
//dr.Close();
//f.sc.Close();





