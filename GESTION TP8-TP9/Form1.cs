using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTION_TP8_TP9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produit p = new Produit();
            p.Show();
        }

        private void gestionClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            c.Show();
        }

        private void gestionCommandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commande c = new commande();
            c.Show();
        }
    }
}
