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
    public partial class ViajesReservados : Form
    {
        private BaseDatos db = new BaseDatos();
        private string idUsuario;
        public ViajesReservados(string idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea cerrar sesión?", "Advertencia", MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    MenuInicio inicio = new MenuInicio();
                    this.Hide();
                    inicio.Show();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente=new Cliente(idUsuario); 
            cliente.Show();
            this.Hide();
        }

        private void ViajesReservados_Load(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        public void ActualizarTabla()
        {
            db.ActualizarTablaViajesReservados(idUsuario, dGVViajesReservados);
        }

        private void dGVViajesReservados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVViajesReservados.Columns[e.ColumnIndex].Name == "Cancelar")
            {
                db.CancelarViaje(idUsuario, dGVViajesReservados.Rows[e.RowIndex].Cells[1].Value.ToString());
                ActualizarTabla();
                MessageBox.Show("Viaje cancelado.");


            }
        }

        private void ViajesReservados_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ViajesReservados_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
