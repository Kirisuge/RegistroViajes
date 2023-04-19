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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Verificar si completo la informacion pertinente
            if(txtEmail.Text=="" || txtPassword.Text == "")
            {
                MessageBox.Show("Uno o mas de un campo estan incompletos");
                return;
            }

            //LLamar a la clase BaseDatos
            BaseDatos baseDatos = new BaseDatos();
            
            //LLamar al metodo VerificarUsuario para revisar que privilegios tiene
            string respuesta=baseDatos.VerificarUsuario(txtEmail.Text,txtPassword.Text);
            switch (respuesta)
            {
                case "":
                    MessageBox.Show("Credenciales incorrectas");
                    break;
                case "empleado":
                    Empleado empleado= new Empleado();
                    this.Hide();
                    empleado.Show();
                    break;
                case "cliente":
                    Cliente cliente= new Cliente();
                    this.Hide();
                    cliente.Show();
                    break;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
