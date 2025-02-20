using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Cliente
    {
        public bool validarUsuario(string usuario, string contra)
        {

            string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexionString))
            {

                con.Open();
                using (SqlCommand consulta = new SqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña", con))
                {

                    consulta.Parameters.AddWithValue("@usuario", usuario);
                    consulta.Parameters.AddWithValue("@contraseña", contra);

                    object result = consulta.ExecuteScalar();
                    int count = (result != null) ? Convert.ToInt32(result) : 0;
                    return count > 0;

                }

            }

        }

        public DataTable ObtenerUsuarios()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, usuario FROM usuarios", conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

    }
}

