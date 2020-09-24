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
    public partial class UserAdmin : Form
    {
        string query = "SELECT * FROM usuarios";
        public UserAdmin()
        {
            InitializeComponent();
        }

        private void UserAdmin_Load(object sender, EventArgs e)
        {
            //limpia el datagrid a fin de no repetir datos al recargar la forma

            dataGridViewUsuarios.Rows.Clear();

            //conexion a bd

            MySqlConnection mySqlConnection = new MySqlConnection("server = localhost; user=root;database=puntodeventa;");
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                dataGridViewUsuarios.Rows.Add(mySqlDataReader.GetInt32(0), mySqlDataReader.GetString(1), mySqlDataReader.GetString(2), mySqlDataReader.GetString(3));
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (textBoxUsuarioId.Text == "")
            {
                MostrarEtiquetaError(textBoxUsuarioId, labelErrorId);
            }
            else if (textBoxNombre.Text == "")
            {
                MostrarEtiquetaError(textBoxNombre, labelErrorNombre);
            }
            else if (textBoxContraseña.Text == "")
            {
                MostrarEtiquetaError(textBoxContraseña, labelErrorContraseña);
            }
            else if (textBoxCorreo.Text == "")
            {
                MostrarEtiquetaError(textBoxCorreo, labelCorreo);
            }
            else
            {
                string queryInsert = "INSERT INTO usuarios (usuarioId, usuarioNombre, usuarioPassword, usuarioCorreo) VALUES ('" + textBoxUsuarioId.Text + "', '" + textBoxNombre.Text + "', SHA2('" + textBoxContraseña.Text + "',256), '" + textBoxCorreo.Text + "')";

                MySqlConnection mySqlConnection = new MySqlConnection("server = localhost; user=root;database=puntodeventa;");
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(queryInsert, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();

                //actualizar el datagrid

                UserAdmin_Load(sender, e);

                //borrar los cuadros de texto

                BorrarFormulario();
            }
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {

        }


        private void MostrarEtiquetaError(TextBox textBox, Label label)
        {
            if (textBox.Text != "")
            {
                textBox.BackColor = Color.White;
                label.Visible = false;
            }
            else
            {
                textBox.BackColor = Color.LightBlue;
                label.Visible = true;
                textBox.Focus();
            }
        }

        private void BorrarFormulario()
        {
            textBoxUsuarioId.Clear();
            textBoxUsuarioId.BackColor = Color.White;
            labelErrorId.Visible = false;
            textBoxNombre.Clear();
            textBoxNombre.BackColor = Color.White;
            labelErrorNombre.Visible = false;
            textBoxContraseña.Clear();
            textBoxContraseña.BackColor = Color.White;
            labelErrorContraseña.Visible = false;
            textBoxCorreo.Clear();
            textBoxCorreo.BackColor = Color.White;
            labelErrorCorreo.Visible = false;
        }

        private void textBoxUsuarioId_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '@' || e.KeyChar == '-' || e.KeyChar == '_' || e.KeyChar == '.')//digitos o back space o @
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxUsuarioId_TextChanged(object sender, EventArgs e)
        {
            MostrarEtiquetaError(textBoxUsuarioId, labelErrorId);
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            MostrarEtiquetaError(textBoxNombre, labelErrorNombre);
        }

        private void textBoxContraseña_TextChanged(object sender, EventArgs e)
        {
            MostrarEtiquetaError(textBoxContraseña, labelErrorContraseña);
        }

        private void textBoxCorreo_TextChanged(object sender, EventArgs e)
        {
            MostrarEtiquetaError(textBoxCorreo, labelErrorCorreo);
        }
    }
}
