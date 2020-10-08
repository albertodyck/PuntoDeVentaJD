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
    public partial class Login : Form
    {
        public static string nombre = "";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                labelInstrucciones.Text = "Teclee el Correo del Usuario";
                CambiaColor(textBoxUser);
                textBoxUser.Focus();
            }
            else if (textBoxPassword.Text=="")
            {
                labelInstrucciones.Text = "Teclee la contraseña";
                CambiaColor(textBoxPassword);
                textBoxPassword.Focus();
            }
            else
            {
                labelInstrucciones.Text = "Acceso Correcto";
                string query = "SELECT * FROM usuarios WHERE usuarioCorreo = '" + textBoxUser.Text + "' AND usuarioPassword = SHA2('" + textBoxPassword.Text + "',256)";

                MySqlConnection mySqlConnection = new MySqlConnection("server = localhost; user=root;database=puntodeventa;");
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    mySqlDataReader.Read();
                    nombre = mySqlDataReader.GetString(1);

                    this.Hide();
                    new Menu().ShowDialog();
                    this.Show();
                }
                else
                {
                    labelInstrucciones.Text = "Usuario o Contraseña Incorrecto";
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void CambiaColor(TextBox textBox)
        {
            if (textBox.Text != "")
            {
                textBox.BackColor = Color.White;
            }
            else
            {
                textBox.BackColor = Color.LightBlue;
            }
        }
        //validacion de nombre de usuario
        private void textBoxUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '@' || e.KeyChar == '-' || e.KeyChar == '_' || e.KeyChar =='.')//digitos o back space o @
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxUser_Click(object sender, EventArgs e)
        {
            textBoxUser.Clear();
            labelInstrucciones.Text = "Teclee el usuario y contraseña";
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.Clear();
            labelInstrucciones.Text = "Teclee el usuario y contraseña";
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {
            CambiaColor(textBoxUser);
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CambiaColor(textBoxPassword);
        }
    }
}
