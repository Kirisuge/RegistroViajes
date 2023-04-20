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

        private void btnViajes_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoViaje nv = new NuevoViaje(this);
            nv.ShowDialog();
        }

        public void ActualizarTabla()
        {
            BaseDatos db = new BaseDatos();
            db.ActualizarTablaViajes("SELECT idViaje, lugarSalida, destino, diaSalida, horaSalida, capacidad, tarifa FROM viajes", dGVViajesDisponibles);
        }
    }
}
