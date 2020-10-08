using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaJD
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFechaHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            labelCajero.Text = "Cajero:" + Login.nombre;
        }

        private void ejecutarPuntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PuntoDeVenta().ShowDialog();
            this.Show();
        }

        private void moduloDeAdministracionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserAdmin().ShowDialog();
            this.Show();
        }

        private void buttonPuntoVenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PuntoDeVenta().ShowDialog();
            this.Show();
        }

        private void buttonUserAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserAdmin().ShowDialog();
            this.Show();
        }
    }
}
