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
            //this.toolTipMensaje.SetToolTip(this.buttonAgregar, "Agrega el Usuario Nuevo en la base de datos")
            this.toolTipMenu.SetToolTip(this.buttonPuntoVenta, "Ejecuta el Punto de venta en Modo de Pantalla Completa");
            this.toolTipMenu.SetToolTip(this.buttonUserAdmin, "Ejecuta el Modulo de administracion de Usuarios, para Agregar, Editar o Eliminar");
            this.toolTipMenu.SetToolTip(this.buttonProductAdmin, "Ejecuta la Administracion web de Productos, requiere autenticacion");
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
