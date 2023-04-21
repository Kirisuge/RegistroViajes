﻿using System;
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
    public partial class Cliente : Form
    {
        private BaseDatos db = new BaseDatos();
        private string idUsuario;
        public Cliente(string idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            ActualizarTabla();

        }

        private void Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
            ViajesReservados viajesReservados = new ViajesReservados(idUsuario);
            viajesReservados.Show();
            this.Hide();
        }

        private void dGVViajesDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVViajesDisponibles.Columns[e.ColumnIndex].Name == "Reservar")
            {
                db.ReservarViaje(idUsuario, dGVViajesDisponibles.Rows[e.RowIndex].Cells[1].Value.ToString());
                MessageBox.Show("Viaje reservado.");
                
            }
        }
        public void ActualizarTabla()
        {
            db.ActualizarTablaViajes("SELECT idViaje, lugarSalida, destino, diaSalida, horaSalida, duracionEstimada, tarifa  FROM viajes", dGVViajesDisponibles);
        }


    }
}
