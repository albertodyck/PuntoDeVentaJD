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
            labelPago.Visible = false;
            textBoxPago.Visible = false;
            panelTitulo.Width = this.Width - 100;
            labelTitulo.Location = new Point((this.Width / 2) - (labelTitulo.Width / 2) - 50, 0);
            labelFechaHora.Location = new Point(this.Width - labelFechaHora.Width - 20, panelTitulo.Height + 3);
            labelCajero.Location = new Point(this.Width - labelCajero.Width - 10, panelTitulo.Height + 3 + labelFechaHora.Height);
            labelCodigo.Location = new Point(pictureBoxLogo.Width + 50, panelTitulo.Height + 23);
            textBoxCodigo.Location = new Point(pictureBoxLogo.Width + 50, panelTitulo.Height + 23 + labelCodigo.Height);
            buttonBuscar.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25, panelTitulo.Height + 3);
            labelCantidad.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25, panelTitulo.Height + 23);
            textBoxCantidad.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25, panelTitulo.Height + 23 + labelCantidad.Height);
            buttonPagar.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25 + textBoxCantidad.Width + 25, panelTitulo.Height + 3);
            labelPago.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25 + textBoxCantidad.Width + 25 + buttonPagar.Width + 25, panelTitulo.Height + 23);
            textBoxPago.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25 + textBoxCantidad.Width + 25 + buttonPagar.Width + 25, panelTitulo.Height + 23 + labelPago.Height);

            textBoxTotal.Location = new Point(this.Width - 20 - textBoxTotal.Width, this.Height - 60 - textBoxTotal.Height);
            labelTotal.Location = new Point(this.Width - 20 - textBoxTotal.Width - labelTotal.Width, this.Height - 60 - textBoxTotal.Height);
            textBoxIVA.Location = new Point(this.Width - 20 - textBoxIVA.Width, this.Height - 60 - textBoxTotal.Height - textBoxIVA.Height-20);
            labelIVA.Location = new Point(this.Width - 20 - textBoxIVA.Width - labelIVA.Width, this.Height - 60 - textBoxTotal.Height - textBoxIVA.Height-20);

            //formato de datagrid
            dataGridView1.Location = new Point(10, pictureBoxLogo.Height + 20);
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height * 7 / 10;

            //Distribuir columnas de datagrid
            dataGridView1.Columns[0].Width = dataGridView1.Width * 10 / 100;
            dataGridView1.Columns[1].Width = dataGridView1.Width * 15 / 100;
            dataGridView1.Columns[2].Width = dataGridView1.Width * 35 / 100;
            dataGridView1.Columns[3].Width = dataGridView1.Width * 10 / 100;
            dataGridView1.Columns[4].Width = dataGridView1.Width * 15 / 100;
            dataGridView1.Columns[5].Width = dataGridView1.Width * 15 / 100;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFechaHora.Text = DateTime.Now.ToLongTimeString();
        }
        //validacion en codigo solo numeros
        private void textBoxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)(Keys.Enter))
            {
                //e.Handled = true;
                textBoxCantidad.Focus();
            }
            else
            {
                e.Handled = true;
            }
        }
        //validacion en cantidad, solo numeros y si es enter regresar a codigo
        private void textBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)(Keys.Enter))
            {
                //e.Handled = true;
                dataGridView1.Rows.Add(textBoxCantidad.Text, textBoxCodigo.Text,"producto", "10", "$55.00", "$55.00");
                BorrarTexto(textBoxCodigo);
                BorrarTexto(textBoxCantidad);
                textBoxCodigo.Focus();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxCodigo_TextChanged(object sender, EventArgs e)
        {

        }
        //hace visibles la etiqueta y 
        private void buttonPagar_Click(object sender, EventArgs e)
        {
            labelPago.Visible = true;
            textBoxPago.Visible = true;
            textBoxPago.Focus();
        }
        //validacion solo numeros en cantidad de pago
        private void textBoxPago_KeyPress(object sender, KeyPressEventArgs e)
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

        #region funcion borrar cuadros de texto
        private void BorrarTexto(TextBox textbox)
        {
            textbox.Text = "";
        }


        #endregion
    }
}
