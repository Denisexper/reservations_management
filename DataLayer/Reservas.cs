using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Reservas
    {
        private string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        public DataTable ObtenerReservas()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM reserva", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AgregarReserva(int id_reserva, int id_cliente, int id_habitacion, decimal precio, decimal? descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO reserva (id_reserva, id_cliente, id_habitacion, precio, descuento, checkin, checkout, fecha_registro, id_usuario) VALUES (@id_reserva, @id_cliente, @id_habitacion, @precio, @descuento, @checkin, @checkout, @fecha_registro, @id_usuario)", con))
                {
                    cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@id_habitacion", id_habitacion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@descuento", (object)descuento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@checkin", checkin);
                    cmd.Parameters.AddWithValue("@checkout", checkout);
                    cmd.Parameters.AddWithValue("@fecha_registro", fecha_registro);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;

                }
            }
        }

        public void ModificarReserva(int id_reserva, int id_cliente, int id_habitacion, decimal precio, decimal? descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE reserva SET id_cliente = @id_cliente, id_habitacion = @id_habitacion, precio = @precio, descuento = @descuento, checkin = @checkin, checkout = @checkout, fecha_registro = @fecha_registro, id_usuario = @id_usuario WHERE id_reserva = @id_reserva", con))
                {
                    cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@id_habitacion", id_habitacion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@descuento", descuento);
                    cmd.Parameters.AddWithValue("@checkin", checkin);
                    cmd.Parameters.AddWithValue("@checkout", checkout);
                    cmd.Parameters.AddWithValue("@fecha_registro", fecha_registro);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarReserva(int id_reserva)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM reserva WHERE id_reserva = @id_reserva", con))
                {
                    cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
