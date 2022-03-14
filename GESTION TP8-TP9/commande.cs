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
    public partial class commande : Form
    {
        public commande()
        {
            InitializeComponent();
        }
            string str;
            SqlConnection cnx;
        private void commande_Load(object sender, EventArgs e)
        {
            str = @"Data Source=DESKTOP-A7ECOHN\SQLEXPRESS;Initial Catalog=GESTION;Integrated Security=True";
            cnx = new SqlConnection(str);

            dataGridView1.Columns.Add("idarticle", "idarticle");
            dataGridView1.Columns.Add("Nomarticle", "Nomarticle");
            dataGridView1.Columns.Add("prixarticle", "prixarticle");
            dataGridView1.Columns.Add("quantite", "quantite");
            dataGridView1.Columns.Add("montant", "montant");

            chargercomclient();
            chargercomproduit();
        }

        public void chargercomclient()
        {
            cnx.Open();
            string c = "select * from Client";
            SqlCommand cmd = new SqlCommand(c, cnx);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Items.Add(r[0].ToString());
              
            }
            cnx.Close();
            r.Close();
        }

        public void chargercomproduit()
        {
            cnx.Open();
            string c = "select * from Produit";
            SqlCommand cmd = new SqlCommand(c, cnx);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                comboBox2.Items.Add(r[0].ToString());

            }
            cnx.Close();
            r.Close ();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx.Open();
            string c = "select * from Client where IdClient = "+comboBox1.Text+"";
            SqlCommand cmd = new SqlCommand(c,cnx);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            
                textBox2.Text= rd[1].ToString();
                textBox3.Text = rd[2].ToString();

            cnx.Close();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx.Open();
            string c = "select * from Produit where IdProduit = " + comboBox2.Text + "";
            SqlCommand cmd = new SqlCommand(c, cnx);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();

            textBox6.Text = r[1].ToString();
            textBox5.Text = r[2].ToString();

            textBox7.Text = "1";
            cnx.Close();
            

        }
        public float clc()
        {
            float s = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                s += float.Parse(dataGridView1.Rows[i].Cells["prixarticle"].Value.ToString());
               
            }
            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                float mnt = int.Parse(textBox7.Text) * float.Parse(textBox5.Text);
                dataGridView1.Rows.Add(comboBox2.Text, textBox6.Text, textBox5.Text, textBox7.Text, mnt.ToString());
                comboBox2.Text="";
                textBox6.Clear();
                textBox5.Clear();
                textBox7.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox4.Text =clc().ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //chaque ligne prend la valeur de i
            int i = dataGridView1.CurrentCell.RowIndex;
            //had i hia la valeur dyal ligne lighadin supp
            dataGridView1.Rows.RemoveAt(i);
            //maj dyal total
            textBox4.Text=clc().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //remplir DB avec un combobox et datetime....
            cnx.Open();
            string s = "insert into Commande values (" + textBox1.Text + ",'" + dateTimePicker1.Value + "'," + comboBox1.Text + ")";
            SqlCommand cmd = new SqlCommand(s,cnx);
            cmd.ExecuteNonQuery();
            MessageBox.Show("commande enregistré");
            cnx.Close();


            //remplir databse avec un datagridview enregistrer tout les info dans la table
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                cnx.Open();
                string a = "insert into Detail values("+ textBox1.Text+","+dataGridView1.Rows[i].Cells["idarticle"].Value+ "," + dataGridView1.Rows[i].Cells["quantite"].Value + ")";
                SqlCommand cmd1 = new SqlCommand(a, cnx);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("LIGNE COMMANDE ENREGISTREE AVEC SUCCES !!!");
                cnx.Close();
            }

            comboBox2.Text = "";
            textBox6.Clear();
            textBox5.Clear();
            textBox7.Clear();
            dataGridView1.Rows.Clear();
            textBox1.Clear();
            comboBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();


        }
    }
}
