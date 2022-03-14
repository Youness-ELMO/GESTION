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
    public partial class Produit : Form
    {
        public Produit()
        {
            InitializeComponent();
        }
        string str;
        SqlConnection cnx;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Produit_Load(object sender, EventArgs e)
        {
            str = @"Data Source=DESKTOP-A7ECOHN\SQLEXPRESS;Initial Catalog=GESTION;Integrated Security=True";
            cnx = new SqlConnection(str);


            dataGridView1.Columns.Add("IdProduit", "IdProduit");
            dataGridView1.Columns.Add("nomProduit", "nomProduit");
            dataGridView1.Columns.Add("prixProduit", "prixProduit");
        }


        public int confirmation()
        {

            string AF = "select count(IdProduit) from Produit where IdProduit= " + textBox1.Text + " ";
            SqlCommand cmd = new SqlCommand(AF, cnx);

            return (int)cmd.ExecuteScalar();
        }









        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Donner l'id du Produit");
            }
            else
            {
                cnx.Open();
                if (confirmation() == 0)
                {
                    string AJ = "insert into Produit values (" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox3.Text + ")";
                    SqlCommand cmd = new SqlCommand(AJ, cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajout bien fait !");
                }

                else
                {
                    MessageBox.Show("exist deja !!");
                }
                cnx.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Donner l'id du Produit");
            }
            else
            {
                cnx.Open();
                if (confirmation() != 0)
                {
                    string M = "update Produit set nomProduit = '" + textBox2.Text + "',prixProduit= " + textBox3.Text + " where IdProduit= " + textBox1.Text + "";
                    SqlCommand cmd = new SqlCommand(M, cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modification bien fait !");
                }

                else
                {
                    MessageBox.Show("n'existe pas");
                }
                cnx.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Donner l'id du Produit");
            }
            else
            {
                cnx.Open();
                if (confirmation() != 0)
                {
                    string S = "delete Produit  where IdProduit= " + textBox1.Text + "";
                    SqlCommand cmd = new SqlCommand(S, cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Suppression bien fait !");
                }

                else
                {
                    MessageBox.Show("n'existe pas");
                }
                cnx.Close();



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public void affichage()
        {
            dataGridView1.Rows.Clear();
            listBox1.Items.Clear();

            cnx.Open();
            string AF = "select * from Produit ";
            SqlCommand cmd = new SqlCommand(AF, cnx);


            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r[0], r[1], r[2]);
                listBox1.Items.Add(" l'Id du produit est: " + r[0] + " le nom du produit est:" + r[1] + " le prix est: " + r[2]);
            }
            cnx.Close();
            r.Close();
        }


        
        private void button5_Click(object sender, EventArgs e)
        {
            int cpt = 0;
            affichage();

          

            if (textBox4.Text == "")
            {
                MessageBox.Show("Donner l'id du Produit");
            }
            else
            {
                int i=0  ;
                cnx.Open();
              
                string ch = "select * from Produit";
                SqlCommand cmd = new SqlCommand(ch, cnx);
                

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {

                    if (textBox4.Text == r[0].ToString()) 
                    {
                       textBox1.Text=r[0].ToString();
                        textBox2.Text = r[1].ToString();
                        textBox3.Text = r[2].ToString();

                        dataGridView1.Rows[i].Selected = true;
                        listBox1.SetSelected(i, true);

                        cpt++;
                        break;
                    }
                    i++;
                } 
               
                if (cpt == 0)
                {
                    MessageBox.Show(" Produit n'exist pas ");
                }

                r.Close();
                cnx.Close();
            }
        }
    }
}