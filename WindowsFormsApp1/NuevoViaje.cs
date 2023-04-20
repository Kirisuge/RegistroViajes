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
        public NuevoViaje()
        {
            InitializeComponent();
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
            DateTime horarioSalida = dTPSalida.Value;
            DateTime horarioLlegada = dTPLlegada.Value;
            string capacidad = textCapacidad.Text.Trim();
            string tarifa = textTarifa.Text.Trim();

            //Hacer las comprobaciones pertinentes
            //Comprobar que ninguno este vacio
            if (lugarSalida == string.Empty || destino == string.Empty || horarioSalida == DateTime.Now || horarioLlegada == DateTime.Now || capacidad == string.Empty || tarifa == string.Empty)
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

            //Compara las dos fechas
            if (CompararFechas(horarioSalida,horarioLlegada) >= 0)
            {
                RegistroInvalido("Favor ingrese fechas válidas.");
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
            db.AgregarNuevoViaje(lugarSalida, destino,horarioSalida,horarioLlegada,int.Parse(capacidad),int.Parse(tarifa));

            //Muestra un mensaje y limpia los campos
            RegistroValido();
        }

        private void RegistroValido()
        {
            MessageBox.Show("¡Viaje creado exitosamente!");
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

        //devuelve un numeor menor que cero si salida es anterior a llegada
        //devuelve 0 si coinciden
        //devuelve un numero mayor a cero si salida es posterior a llegada
        private int CompararFechas(DateTime salida, DateTime llegada)
        {
            return DateTime.Compare(salida, llegada);
        }

        //Reestablece los valores de los campos
        private void LimpiarCampos()
        {
            cBSalida.Text= string.Empty;
            cBDestino.Text= string.Empty;
            dTPLlegada.Value = DateTime.Now;
            dTPSalida.Value= DateTime.Now;
            textCapacidad.Clear();
            textTarifa.Clear();
        }
    }
}

