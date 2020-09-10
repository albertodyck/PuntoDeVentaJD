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
    public partial class PuntoDeVenta : Form
    {
        public PuntoDeVenta()
        {
            InitializeComponent();
        }

        private void PuntoDeVenta_Load(object sender, EventArgs e)
        {
            panelTitulo.Width = this.Width - 100;
            labelTitulo.Location = new Point((this.Width/2) - (labelTitulo.Width/2)-50,0);
            labelFechaHora.Location = new Point(this.Width-labelFechaHora.Width, panelTitulo.Height+3);
            labelCajero.Location = new Point(this.Width-labelCajero.Width, panelTitulo.Height+3+labelFechaHora.Height);
            labelCodigo.Location = new Point(pictureBoxLogo.Width+50, panelTitulo.Height + 23);
            textBoxCodigo.Location = new Point(pictureBoxLogo.Width+50, panelTitulo.Height + 23 + labelCodigo.Height);
            buttonBuscar.Location = new Point(pictureBoxLogo.Width+50+textBoxCodigo.Width+25, panelTitulo.Height+3);
            labelCantidad.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25, panelTitulo.Height + 23);
            textBoxCantidad.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25, panelTitulo.Height + 23 + labelCantidad.Height);

            //formato de datagrid
            dataGridView1.Location = new Point(10, pictureBoxLogo.Height+20);
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height * 7 / 10;

            //Distribuir columnas de datagrid


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFechaHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBoxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar ==8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxCodigo_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
