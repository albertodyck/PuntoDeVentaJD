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
            this.toolTipMensaje.SetToolTip(this.textBoxUsuarioId, "Ingrese el Numero de Usuario");
            this.toolTipMensaje.SetToolTip(this.textBoxNombre, "Ingrese el Nombre del Usuario");
            this.toolTipMensaje.SetToolTip(this.textBoxContraseña, "Ingrese la Contraseña para el usuario");
            this.toolTipMensaje.SetToolTip(this.textBoxCorreo, "Ingrese el correo electronico del Usuario, este sera el nombre para hacer el login");
            this.toolTipMensaje.SetToolTip(this.buttonAgregar, "Agrega el Usuario Nuevo en la base de datos");
            this.toolTipMensaje.SetToolTip(this.buttonBorrar, "Elimina el usuario seleccionado y presente en el formulario");
            this.toolTipMensaje.SetToolTip(this.buttonGuardarEdicion, "Guarda los datos capturados en el formulario, teclee la contraseña siempre");
            this.toolTipMensaje.SetToolTip(this.buttonLimpiar, "Vacia el formulario dejando los campos en blanco");
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

        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxUsuarioId.Text = dataGridViewUsuarios[0, e.RowIndex].Value.ToString();
            textBoxNombre.Text = dataGridViewUsuarios[1, e.RowIndex].Value.ToString();
            textBoxContraseña.Text = dataGridViewUsuarios[2, e.RowIndex].Value.ToString();
            textBoxCorreo.Text = dataGridViewUsuarios[3, e.RowIndex].Value.ToString();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar el Usuario: " + textBoxNombre.Text, "Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                string queryEliminar = "DELETE FROM usuarios WHERE usuarioId = '" + textBoxUsuarioId.Text + "'";
                //MessageBox.Show(queryEliminar);

                MySqlConnection mySqlConnection = new MySqlConnection("server = localhost; user=root;database=puntodeventa;");
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(queryEliminar, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();

                //actualizar el datagrid
                BorrarFormulario();
                UserAdmin_Load(sender, e);
            }
        }

        private void buttonGuardarEdicion_Click(object sender, EventArgs e)
        {
            string queryActualizar = "UPDATE usuarios SET usuarioNombre = '" + textBoxNombre.Text + "', UsuarioPassword = SHA2('" + textBoxContraseña.Text + "',256), usuarioCorreo = '" + textBoxCorreo.Text + "' WHERE usuarioId = '" + textBoxUsuarioId.Text + "'";
            MessageBox.Show(queryActualizar);

            MySqlConnection mySqlConnection = new MySqlConnection("server = localhost; user=root;database=puntodeventa;");
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(queryActualizar, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();

            //actualizar el datagrid
            BorrarFormulario();
            UserAdmin_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorrarFormulario();
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

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
