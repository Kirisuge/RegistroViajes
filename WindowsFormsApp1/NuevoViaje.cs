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
    public partial class NuevoViaje : Form
    {
        Empleado empleadoForms;

        public Empleado EmpleadoForms
        {
            get { return empleadoForms; }
            set { empleadoForms = value; }
        }

        public NuevoViaje(Empleado empleadoForms)
        {
            InitializeComponent();
            EmpleadoForms = empleadoForms;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearViaje_Click(object sender, EventArgs e)
        {
            //Tomar los valores de las entradas de texto y horas
            string lugarSalida = cBSalida.Text;
            string destino = cBDestino.Text;
            DateTime diaSalida = dTPSalida.Value.Date;
            string horaSalida = cBHoraSalida.Text;
            string capacidad = textCapacidad.Text.Trim();
            string tarifa = textTarifa.Text.Trim();

            //Hacer las comprobaciones pertinentes
            //Comprobar que ninguno este vacio
            if (lugarSalida == string.Empty || destino == string.Empty || horaSalida == string.Empty || capacidad == string.Empty || tarifa == string.Empty || diaSalida == DateTime.Today)
            {
                RegistroInvalido("Favor completar todos los campos");
                return;
            }

            // Validar que el lugar de salida no es igual al lugar de llegada
            if (lugarSalida == destino)
            {
                RegistroInvalido("La sucursal de salida y la de llegada para el viaje no pueden ser las mismas.");
                return;
            }

            //Comprobar que la tarifa y la capacidad son numeros enteros
            if (ComprobarSiEsNumero(capacidad) == false || ComprobarSiEsNumero(tarifa) == false)
            {
                RegistroInvalido("Favor ingrese cantidades válidas");
                return;
            }

            //Crea objeto base de datos y se llama al metodo para agregar un viaje 
            BaseDatos db = new BaseDatos();
            db.AgregarNuevoViaje(lugarSalida, destino,diaSalida,horaSalida,int.Parse(capacidad),int.Parse(tarifa));

            //Muestra un mensaje y limpia los campos
            RegistroValido();
        }

        private void RegistroValido()
        {
            MessageBox.Show("¡Viaje creado exitosamente!");
            EmpleadoForms.ActualizarTabla();
            LimpiarCampos();
        }

        //Mensaje de error
        private void RegistroInvalido(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        //Devuelve true si la cadena es un numero, de lo contrario, false
        private bool ComprobarSiEsNumero(string cadena)
        {
            int numero;
            return int.TryParse(cadena, out numero);
        }

        //Reestablece los valores de los campos
        private void LimpiarCampos()
        {
            cBSalida.Text= string.Empty;
            cBDestino.Text= string.Empty;
            cBHoraSalida.Text = string.Empty;
            dTPSalida.Value= DateTime.Now;
            textCapacidad.Clear();
            textTarifa.Clear();
        }

        private void NuevoViaje_Load(object sender, EventArgs e)
        {

        }

        private void dTPSalida_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

