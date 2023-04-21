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
                    respesta = reader["idUsuario"].ToString();
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

        public void AgregarNuevoViaje(string lugarSalida, string destino, DateTime diaSalida, DateTime horaSalida, DateTime duracion, int capacidad, int tarifa)
        {
            conexion.Open();
            string sql = "INSERT INTO viajes (lugarSalida, destino, diaSalida, horaSalida, duracionEstimada, capacidad, tarifa) " +
                "VALUES (@lugarSalida, @destino, @diaSalida, @horaSalida, @duracion, @capacidad, @tarifa) ";

            SqlCommand command = new SqlCommand(sql, conexion);
            
            command.Parameters.AddWithValue("@lugarSalida", lugarSalida);
            command.Parameters.AddWithValue("@destino", destino);
            command.Parameters.AddWithValue("@diaSalida", diaSalida);
            command.Parameters.AddWithValue("@horaSalida", horaSalida.TimeOfDay);
            command.Parameters.AddWithValue("@duracion", duracion.TimeOfDay);
            command.Parameters.AddWithValue("@capacidad", capacidad);
            command.Parameters.AddWithValue("@tarifa", tarifa);

            command.ExecuteNonQuery();

            conexion.Close();
        }


        public void ActualizarViaje(int id, string lugarSalida, string destino, DateTime diaSalida, DateTime horaSalida, DateTime duracion, int capacidad, int tarifa)
        {
            conexion.Open();
            string query = "UPDATE viajes SET lugarSalida = @lugarSalida, destino = @destino, " +
                "diaSalida = @diaSalida, horaSalida = @horaSalida, duracionEstimada = @duracion, capacidad = @capacidad, " +
                "tarifa = @tarifa WHERE idViaje = @id";

            SqlCommand command = new SqlCommand(query, conexion);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@lugarSalida", lugarSalida);
            command.Parameters.AddWithValue("@destino", destino);
            command.Parameters.AddWithValue("@diaSalida", diaSalida);
            command.Parameters.AddWithValue("@horaSalida", horaSalida.TimeOfDay);
            command.Parameters.AddWithValue("@duracion", duracion.TimeOfDay);
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
             

            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@Email", email);
            int count = (int)command.ExecuteScalar();

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


            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgv.DataSource = dataTable;

            conexion.Close();
        }
        public void ActualizarTablaViajesReservados(string idUsuario, DataGridView dgv)
        {
            conexion.Open();
            string queryBoletos = "SELECT idViaje FROM boletos WHERE idCliente=@idUsuario";
            SqlCommand commandBoletos = new SqlCommand(queryBoletos, conexion);
            commandBoletos.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader readerBoletos = commandBoletos.ExecuteReader();


            List<string> viajesUsuario = new List<string>();
            while (readerBoletos.Read())
            {
                string idViaje = readerBoletos["idViaje"].ToString();
                viajesUsuario.Add(idViaje);
            }
            readerBoletos.Close();
            if (viajesUsuario.Count == 0)
            {
                MessageBox.Show("El usuario no tiene boletos comprados");
                return;
            }

            string queryViajes = "SELECT idViaje, lugarSalida, destino, diaSalida, horaSalida FROM viajes WHERE idViaje IN (" + string.Join(",", viajesUsuario) + ")";
            SqlCommand commandViajes = new SqlCommand(queryViajes, conexion);

            SqlDataAdapter adapter = new SqlDataAdapter(commandViajes);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgv.DataSource = dataTable;


            conexion.Close();

        }
        public void ReservarViaje(string idUsuario, string idViaje)
        {
            conexion.Open();
            string query = "INSERT INTO boletos (idViaje,idCliente) " +
                "VALUES (@idViaje,@idUsuario)";

            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@idViaje", idViaje);
            command.Parameters.AddWithValue("@idUsuario", idUsuario);
            command.ExecuteNonQuery();


            conexion.Close();
        }
        public void CancelarViaje(string idUsuario, string idViaje)
        {
            conexion.Open();
            string query = "DELETE FROM boletos WHERE idViaje = @idViaje AND idCliente = @idUsuario";

            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@idViaje", idViaje);
            command.Parameters.AddWithValue("@idUsuario", idUsuario);
            command.ExecuteNonQuery();


            conexion.Close();
        }
    }
}
