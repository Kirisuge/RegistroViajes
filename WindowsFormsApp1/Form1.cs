using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string dataBaseStr = "server=localhost;database=RegistroAutobuses;integrated security=true";

        SqlConnection conexion = new SqlConnection(dataBaseStr);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string query = $"SELECT * FROM usuarios WHERE email='{txtEmail.Text}' AND contra = '{txtPassword.Text}'";

            SqlCommand command = new SqlCommand(query, conexion);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

                if (reader["privilegios"].ToString() == "true")
                {
                    Empleado empleado = new Empleado();
                    empleado.Show();
                    this.Hide();
                }
                else
                {
                    Cliente cliente = new Cliente();
                    cliente.Show();
                    this.Hide();
                }
            }
            conexion.Close();
        }
    }
}
