using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar implementacion de base de datos 
using System.Data.SqlClient;
using System.Windows.Forms;

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
        
    }
}
