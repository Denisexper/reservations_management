using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentatonLayer
{
    public partial class statusReserva : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) //si no hay sesion
            {
                Response.Redirect("index.aspx"); //lo mandamos al login
            }
        }

        protected void btnBuscarReserva_Click(object sender, EventArgs e)
        {
            string codigoReserva = txtCodigoReserva.Text.Trim(); // Obtener el código de reserva del input del usuario

            obtenerReserva obtenerRes = new obtenerReserva();
            try
            {
                // Obtener la reserva por el código
                DataTable dtReserva = obtenerRes.ObtenerReservaPorCodigo(codigoReserva);

                if (dtReserva.Rows.Count > 0)
                {
                    // Si se encuentra la reserva, redirigir a la página de detalles con el código de reserva en la URL
                    Response.Redirect("DetallesReserva.aspx?codigo=" + codigoReserva);
                }
                else
                {
                    // Mostrar un mensaje si no se encuentra la reserva
                    Label2.Text = "No se encontró ninguna reserva con ese código.";
                }
            }
            catch (Exception ex)
            {
                Label2.Text = "Ocurrió un error: " + ex.Message;
            }
        }
    }
}