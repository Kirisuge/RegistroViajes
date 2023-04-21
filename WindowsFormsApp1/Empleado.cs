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
    public partial class Empleado : Form
    {
        BaseDatos db = new BaseDatos();

        public Empleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            ActualizarTabla();
        }


        private void Empleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVViajesDisponibles.Columns[e.ColumnIndex].Name == "Editar")
            {
                 EditarViaje edtViaje = new EditarViaje(this,dGVViajesDisponibles,e);
                 edtViaje.ShowDialog();
            }
            if (dGVViajesDisponibles.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                //Muestra una ventana de confirmacion y elimina el viaje seleccionado si se presiona Si
                if (MessageBox.Show("Se eliminará el viaje seleccionado, ¿desea continua?","Advertencia", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    db.EliminarViaje(int.Parse(dGVViajesDisponibles.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    ActualizarTabla();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoViaje nv = new NuevoViaje(this);
            nv.ShowDialog();
        }

        public void ActualizarTabla()
        {
            
            db.ActualizarTablaViajes("SELECT idViaje, lugarSalida, destino, diaSalida, horaSalida, duracionEstimada, capacidad, tarifa  FROM viajes", dGVViajesDisponibles);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Advertencia", MessageBoxButtons.YesNoCancel) == DialogResult.Yes);
            {
                MenuInicio inicio = new MenuInicio();
                this.Hide();
                inicio.Show();
            }
        }
    }
}
