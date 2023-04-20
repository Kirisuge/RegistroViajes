using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar implementacion de base de datos 
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data;

namespace WindowsFormsApp1
{

    internal class BaseDatos
    {
        //Establecer conexion a la base de datos
        private static string dataBaseStr = "server=localhost;database=RegistroAutobuses;integrated security=true";
        private SqlConnection conexion = new SqlConnection(dataBaseStr);
        public BaseDatos() { 

        }

        public string VerificarUsuario(string email,string password) {
            string respesta = "";
            //abrir la conexion
            conexion.Open();


            //Realizar una consulta a la base de datos para verificar las credenciales del usuario
            string query = $"SELECT * FROM usuarios WHERE email='{email}' AND contra = '{password}'";
            SqlCommand command = new SqlCommand(query, conexion);

            //Transformar la respuesta del query para poder leerla
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                if (reader["privilegios"].ToString() == "true")
                {
                    respesta="empleado";
                }
                else
                {
                    respesta = "cliente";
                }
            }
            //Cerrar la conexion
            conexion.Close();
            return respesta;

        }

        public void AgregarRegistroUsuario(string nombre,string apellido,string email, string clave)
        {
            conexion.Open();
            string sql = "INSERT INTO usuarios (nombre, apellido, email, contra, privilegios) " +
                "VALUES (@nombre, @apellido, @email, @contra, @privilegios)";

            SqlCommand command = new SqlCommand(sql,conexion);

            //command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@apellido", apellido);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@contra", clave);
            command.Parameters.AddWithValue("@privilegios", "cliente");
            command.ExecuteNonQuery();

            conexion.Close();
        }

        public void AgregarNuevoViaje(string lugarSalida, string destino, DateTime diaSalida, string horaSalida,int capacidad, int tarifa)
        {
            conexion.Open();
            string sql = "INSERT INTO viajes (lugarSalida, destino, diaSalida, horaSalida, capacidad, tarifa) " +
                "VALUES (@lugarSalida, @destino, @diaSalida, @horaSalida, @capacidad, @tarifa)";

            SqlCommand command = new SqlCommand(sql, conexion);
            
            command.Parameters.AddWithValue("@lugarSalida", lugarSalida);
            command.Parameters.AddWithValue("@destino", destino);
            command.Parameters.AddWithValue("@diaSalida", diaSalida);
            command.Parameters.AddWithValue("@horaSalida", horaSalida);
            command.Parameters.AddWithValue("@capacidad", capacidad);
            command.Parameters.AddWithValue("@tarifa", tarifa);
            command.ExecuteNonQuery();

            conexion.Close();
        }


        public void ActualizarViaje(int id, string lugarSalida, string destino, DateTime diaSalida, string horaSalida, int capacidad, int tarifa)
        {
            conexion.Open();
            string query = "UPDATE viajes SET lugarSalida = @lugarSalida, destino = @destino, " +
                "diaSalida = @diaSalida, horaSalida = @horaSalida, capacidad = @capacidad, " +
                "tarifa = @tarifa WHERE idViaje = @id";

            SqlCommand command = new SqlCommand(query, conexion);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@lugarSalida", lugarSalida);
            command.Parameters.AddWithValue("@destino", destino);
            command.Parameters.AddWithValue("@diaSalida", diaSalida);
            command.Parameters.AddWithValue("@horaSalida", horaSalida);
            command.Parameters.AddWithValue("@capacidad", capacidad);
            command.Parameters.AddWithValue("@tarifa", tarifa);
            command.ExecuteNonQuery();
            conexion.Close();

        }

        public void EliminarViaje (int id)
        {
            conexion.Open();
            string query = "DELETE FROM viajes WHERE idViaje = @id";
            SqlCommand command = new SqlCommand(query, conexion);

            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public bool EmailExiste(string email)
        {
            conexion.Open();

            string query = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";
            int count = 0;

            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@Email", email);
            count = (int)command.ExecuteScalar();

            conexion.Close();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void ActualizarTablaViajes(string query, DataGridView dgv)
        {
            conexion.Open();
            SqlCommand command = new SqlCommand(query, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(command);


            DataTable dataTable= new DataTable();
            adapter.Fill(dataTable);
            dgv.DataSource = dataTable;

            conexion.Close();
        }
    }
}
