using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class Habitaciones
    {
        private string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataTable ObtenerHabitaciones()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Habitaciones", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AgregarHabitacion(int numero, string descripcion, int huespedes, int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Habitaciones " +
                    "(numero, descripcion, huespedes, id_usuario) " +
                    "VALUES(@numero, @descripcion, @huespedes, @id_usuario)", con))
                {
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@huespedes", huespedes);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool UsuarioExiste(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idUsuario);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Retorna true si el usuario existe
            }
        }

        public bool ModificarHabitacion(int id, int numero, string descripcion, int huespedes, int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE habitaciones SET numero = @numero," +
                    "descripcion = @descripcion," +
                    "huespedes = @huespedes," +
                    "id_usuario = @idUsuario " +
                    "WHERE id_habitaciones = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@huespedes", huespedes);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool EliminarHabitacion(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM habitaciones " +
                    "WHERE id_habitaciones = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}
