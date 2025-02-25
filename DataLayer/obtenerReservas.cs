using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class obtenerReservas
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        // Método para obtener la información de la reserva por el código de reserva
        public DataTable ObtenerReservaPorCodigo(string codigoReserva)
        {
            // Desglosar el código de reserva para extraer id_reserva
            string[] partes = codigoReserva.Split('-');
            if (partes.Length >= 2)
            {
                int id_reserva = int.Parse(partes[0].Replace("RES", ""));

                // Obtener la reserva basada en id_reserva
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM reserva WHERE id_reserva = @id_reserva", con))
                    {
                        cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            else
            {
                throw new ArgumentException("El código de reserva no es válido.");
            }
        }
    }
    
    
}
