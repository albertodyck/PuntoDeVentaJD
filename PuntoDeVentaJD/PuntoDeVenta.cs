using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PuntoDeVentaJD
{
    public partial class PuntoDeVenta : Form
    {
        float total = 0;
        float IVA = 0;
       
        public PuntoDeVenta()
        {
            InitializeComponent();
        }

        private void PuntoDeVenta_Load(object sender, EventArgs e)
        {
            //colocar nombre del cajero
            labelCajero.Text = "Cajero:" + Login.nombre;
            Invisibles();
            //diseño superior al datagrid
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
            textBoxCambio.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25 + textBoxCantidad.Width + 25 + buttonPagar.Width + 25 + textBoxPago.Width + 25, panelTitulo.Height + 23 + labelCambio.Height);
            labelCambio.Location = new Point(pictureBoxLogo.Width + 50 + textBoxCodigo.Width + 25 + buttonBuscar.Width + 25 + textBoxCantidad.Width + 25 + buttonPagar.Width + 25 + textBoxPago.Width + 25, panelTitulo.Height + 23);

            //diseño inferior al datagrid
            textBoxTotal.Location = new Point(this.Width - 20 - textBoxTotal.Width, this.Height - 60 - textBoxTotal.Height);
            labelTotal.Location = new Point(this.Width - 20 - textBoxTotal.Width - labelTotal.Width, this.Height - 60 - textBoxTotal.Height);
            textBoxIVA.Location = new Point(this.Width - 20 - textBoxIVA.Width, this.Height - 60 - textBoxTotal.Height - textBoxIVA.Height-20);
            labelIVA.Location = new Point(this.Width - 20 - textBoxIVA.Width - labelIVA.Width, this.Height - 60 - textBoxTotal.Height - textBoxIVA.Height-20);
            buttonGuardarVenta.Location = new Point(10, this.Height - 60 - buttonGuardarVenta.Height);
            buttonEliminarVenta.Location = new Point(10 + buttonGuardarVenta.Width + 25, this.Height - 60 - buttonEliminarVenta.Height);
            buttonCancelarArticulo.Location = new Point(10 + buttonGuardarVenta.Width + 25 + buttonEliminarVenta.Width +25, this.Height - 60 - buttonCancelarArticulo.Height);
            textBoxCaptura.Location = new Point(10 + buttonGuardarVenta.Width + 25 + buttonEliminarVenta.Width + 25 +buttonCancelarArticulo.Width + 25, this.Height - 60 - textBoxCaptura.Height);
            textBoxCaptura.Focus();
            textBoxCaptura.Width = (this.Width-20) - (75 + buttonGuardarVenta.Width + buttonEliminarVenta.Width + buttonCancelarArticulo.Width + textBoxTotal.Width + labelTotal.Width + 25);

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
            else if (true)
            {
                textBoxCambio.Visible = true;
                labelCambio.Visible = true;
                textBoxCambio.Focus();
            }
            else
            {
                e.Handled = true;
            }
        }

        #region funcion limpiar cuadros de texto
        private void BorrarTexto(TextBox textbox)
        {
            textbox.Text = "";
        }
        #endregion

        private void Invisibles()
        {
            labelPago.Visible = false;
            textBoxPago.Visible = false;
            textBoxPago.Clear();
            textBoxCambio.Visible = false;
            textBoxCambio.Clear();
            labelCambio.Visible = false;
            textBoxIVA.Clear();
            textBoxTotal.Clear();
            textBoxCantidad.Clear();
            textBoxCodigo.Clear();

        }

        private void textBoxCaptura_KeyPress(object sender, KeyPressEventArgs e)
        {
            string query;
            string cantidad;
            string codigo;

            if (e.KeyChar == 13 && textBoxCaptura.Text != "" )
            {
                if (textBoxCaptura.Text.IndexOf("*")== -1)
                {
                    query = "SELECT * FROM productos WHERE Codigo=" + textBoxCaptura.Text;
                    codigo = textBoxCaptura.Text;
                    textBoxCodigo.Text = codigo;
                    cantidad = "1";
                    textBoxCantidad.Text = cantidad;
                }
                else
                {
                    string[] cantidad_producto = textBoxCaptura.Text.Split('*');
                    query = "SELECT * FROM productos WHERE Codigo=" + cantidad_producto[1];
                    cantidad = cantidad_producto[0];
                    codigo = cantidad_producto[1];
                    textBoxCodigo.Text = codigo;
                    textBoxCantidad.Text = cantidad;

                }

                //conexion bd
                MySqlConnection mySqlConnection = new MySqlConnection("server = localhost; user=root;database=puntodeventa;");
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                //llenar datagrid con base de datos

                while (mySqlDataReader.Read())
                {
                    float qty = float.Parse(cantidad);
                    //cantidad por precio en bd
                    float totalLinea = qty * mySqlDataReader.GetFloat(3);
                    float iva_venta = totalLinea * 16/100;
                    IVA = IVA + iva_venta;

                    dataGridView1.Rows.Add(cantidad, codigo, mySqlDataReader.GetString(2), mySqlDataReader.GetInt16(1), mySqlDataReader.GetFloat(3), string.Format("{0:.##}",totalLinea));
                }

                textBoxCaptura.Clear();
                textBoxCaptura.Focus();

                //calculo de total y despliegue en textbox

                total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += float.Parse(dataGridView1[5,i].Value.ToString());
                }

                textBoxIVA.Text = "$" + string.Format("{0:.##}", IVA);
                textBoxTotal.Text = "$" + string.Format("{0:.##}", total);
            }
        }

        private void textBoxCaptura_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                float pago = float.Parse(textBoxCaptura.Text.Remove(textBoxCaptura.TextLength - 1));

                textBoxPago.Visible = true;
                labelPago.Visible = true;
                textBoxPago.Text = "$" + pago;

                labelCambio.Visible = true;
                textBoxCambio.Visible = true;
                textBoxCambio.Text = "$" + (pago - total);

                textBoxCaptura.Focus();
                textBoxCaptura.Clear();

                //limpiar el datagrid
                dataGridView1.Rows.Clear();

                buttonGuardarVenta.Focus();
            }
        }

        private void buttonGuardarVenta_Click(object sender, EventArgs e)
        {
            Invisibles();
            IVA = 0;
            total = 0;
            textBoxCaptura.Focus();
        }
    }
}
