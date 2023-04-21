using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegistrarCuenta : Form
    {
        public RegistrarCuenta()
        {
            InitializeComponent();
        }

        private void RegistrarCuenta_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            MenuInicio inicio = new MenuInicio();
            this.Hide();
            inicio.Show();
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            BaseDatos db = new BaseDatos();
            string nombre = txtNom.Text.Trim();
            string apellido = textApellido.Text.Trim();
            string email = textEmail.Text.Trim();
            string clave = textClave.Text.Trim();

            if (nombre == string.Empty || apellido == string.Empty || email == string.Empty || clave == string.Empty)
            {
                RegistroNoValido("Debe llenar todos los campos para continuar.");
                return;
            }

            if (EmailEsValido(email) == false)
            {
                RegistroNoValido("Ingrese un email valido.");
                return;
            }
            else if (db.EmailExiste(email) == true)
            {
                RegistroNoValido("Email ya registrado para una cuenta.");
                return;
            }

            if (ClaveEsValida(clave) == false)
            {
                RegistroNoValido("La clave debe tener al menos 8 caracteres y un número.");
                return;
            }

            db.AgregarRegistroUsuario(nombre,apellido,email, clave);
            MessageBox.Show("¡Cuenta creada exitosamente!");
            RegistroValido();

        }
        private void RegistroValido()
        {
            LimpiarTextBox();
            Form1 InicioSesion= new Form1();
            this.Hide();
            InicioSesion.Show();
        }

        private bool ClaveEsValida (string clave)
        {
            string numeros = "123456789";
            int contadorNumeros = 0;

            if (clave.Length < 8)
            {
                return false;
            }

            foreach(char c in clave)
            {
                if (numeros.Contains(c))
                {
                    contadorNumeros++;
                }
            }

            if (contadorNumeros >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool EmailEsValido(string email)
        {
            if (email.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void RegistroNoValido(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void LimpiarTextBox()
        {
            txtNom.Clear();
            textApellido.Clear();
            textEmail.Clear();
            textClave.Clear();
        }

        private void textApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
