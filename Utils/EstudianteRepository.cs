using JSS6.Models;
using JSS6.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSS6.Utils
{
    public class EstudianteRepository
    {
        private MySqlConnection connection;

        public EstudianteRepository()
        {
            var fileAccessHelper = new FileAccessHelper();
            connection = fileAccessHelper.GetConnection();
        }

        // Método para insertar un estudiante
        public bool InsertarEstudiante(EstudianteModel estudiante)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO estudiantes (Nombre, Apellido, Edad) VALUES (@Nombre, @Apellido, @Edad)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                cmd.Parameters.AddWithValue("@Edad", estudiante.Edad);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Método para consultar estudiantes
        public List<EstudianteModel> ConsultarEstudiantes()
        {
            List<EstudianteModel> estudiantes = new List<EstudianteModel>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM estudiantes";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    estudiantes.Add(new EstudianteModel
                    {
                        Codigo = reader.GetInt32("Codigo"),
                        Nombre = reader.GetString("Nombre"),
                        Apellido = reader.GetString("Apellido"),
                        Edad = reader.GetInt32("Edad")
                    });
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return estudiantes;
        }

        // Método para editar estudiante
        public bool EditarEstudiante(EstudianteModel estudiante)
        {
            try
            {
                connection.Open();
                string query = "UPDATE estudiantes SET Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad WHERE Codigo = @Codigo";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                cmd.Parameters.AddWithValue("@Edad", estudiante.Edad);
                cmd.Parameters.AddWithValue("@Codigo", estudiante.Codigo);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Método para eliminar estudiante
        public bool EliminarEstudiante(int codigo)
        {
            try
            {
                connection.Open();
                string query = "DELETE FROM estudiantes WHERE Codigo = @Codigo";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
