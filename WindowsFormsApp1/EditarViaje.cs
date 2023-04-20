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
    public partial class EditarViaje : Form
    {
        DataGridView dgv;
        Empleado empleadoForm;
        DataGridViewCellEventArgs cellEvent;
        int idViaje;

        public EditarViaje(Empleado empleado, DataGridView dg, DataGridViewCellEventArgs e)
        {
            InitializeComponent();
            this.dgv = dg;
            this.empleadoForm = empleado;
            this.cellEvent = e;
            LlenarOpciones();
        }

        //Asigna los valores del viaje seleccionado a las entradas
        private void LlenarOpciones()
        {
            idViaje = int.Parse(dgv.Rows[cellEvent.RowIndex].Cells[2].Value.ToString());
            cBSalida.Text = dgv.Rows[cellEvent.RowIndex].Cells[3].Value.ToString();
            cBDestino.Text = dgv.Rows[cellEvent.RowIndex].Cells[4].Value.ToString();
            dTPSalida.Text = dgv.Rows[cellEvent.RowIndex].Cells[5].Value.ToString();
            cBHoraSalida.Text = dgv.Rows[cellEvent.RowIndex].Cells[6].Value.ToString();
            textCapacidad.Text = dgv.Rows[cellEvent.RowIndex].Cells[7].Value.ToString();
            textTarifa.Text = dgv.Rows[cellEvent.RowIndex].Cells[8].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string lugarSalida = cBSalida.Text;
            string destino = cBDestino.Text;
            DateTime diaSalida = dTPSalida.Value.Date;
            string horaSalida = cBHoraSalida.Text;
            string capacidad = textCapacidad.Text.Trim();
            string tarifa = textTarifa.Text.Trim();

            //Comprueba que los campos no esten vacios
            if (diaSalida.Date == DateTime.Today || capacidad == string.Empty || tarifa == string.Empty)
            {
                RegistroNoValido("Favor ingresar datos válidos.");
                return;
            }

            // Comprueba que el destino y el lugar de salida no sean iguales
            if (lugarSalida == destino)
            {
                RegistroNoValido("Las sucursales de destino y el de salida no pueden coincidir.");
                return;
            }

            //Comprobar que la tarifa y la capacidad son numeros enteros
            if (ComprobarSiEsNumero(capacidad) == false || ComprobarSiEsNumero(tarifa) == false)
            {
                RegistroNoValido("Favor ingrese cantidades válidas");
                return;
            }

            BaseDatos db = new BaseDatos();
            db.ActualizarViaje(idViaje,lugarSalida,destino,diaSalida,horaSalida,int.Parse(capacidad),int.Parse(tarifa));
            empleadoForm.ActualizarTabla();
            MessageBox.Show("¡Viaje modificado exitosamente!");
            this.Hide();

        }

        private void RegistroNoValido(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
        private bool ComprobarSiEsNumero(string cadena)
        {
            int numero;
            return int.TryParse(cadena, out numero);
        }
    }
}
