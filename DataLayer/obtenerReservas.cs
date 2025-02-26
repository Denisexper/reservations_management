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
            
            
            string idReservaStr = codigoReserva.Substring(0, 1); //depende la longitud que tenga el id_reserva en este caso es 1
            int id_reserva;

            if (int.TryParse(idReservaStr, out id_reserva))
            {
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
