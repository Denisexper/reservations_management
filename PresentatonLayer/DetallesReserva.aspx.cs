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
    public partial class DetallesReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) //si no hay sesion
            {
                Response.Redirect("index.aspx"); //lo mandamos al login
            }
            if (!IsPostBack)
            {
                // Obtener el código de reserva desde la URL
                string codigoReserva = Request.QueryString["codigo"];

                if (!string.IsNullOrEmpty(codigoReserva))
                {
                    obtenerReserva obtenerRes = new obtenerReserva();
                    try
                    {
                        // Obtener la reserva usando el código
                        DataTable dtReserva = obtenerRes.ObtenerReservaPorCodigo(codigoReserva);

                        if (dtReserva.Rows.Count > 0)
                        {
                            // Mostrar los detalles en los Labels
                            lblIDReserva.Text = dtReserva.Rows[0]["id_reserva"].ToString();
                            lblIDCliente.Text = dtReserva.Rows[0]["id_cliente"].ToString();
                            lblIDHabitacion.Text = dtReserva.Rows[0]["id_habitacion"].ToString();
                            lblPrecioTotal.Text = "$" + Convert.ToDecimal(dtReserva.Rows[0]["precio"]).ToString("0.00");
                            lblCheckIn.Text = Convert.ToDateTime(dtReserva.Rows[0]["checkin"]).ToString("dd/MM/yyyy");
                            lblCheckOut.Text = Convert.ToDateTime(dtReserva.Rows[0]["checkout"]).ToString("dd/MM/yyyy");
                            lblFechaRegistro.Text = Convert.ToDateTime(dtReserva.Rows[0]["fecha_registro"]).ToString("yyyy-MM-dd");
                            lblIDUsuario.Text = dtReserva.Rows[0]["id_usuario"].ToString();
                        }
                        else
                        {
                            lblMensaje.Text = "No se encontró la reserva con el código proporcionado.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                    }
                }
                else
                {
                    lblMensaje.Text = "No se proporcionó un código de reserva.";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("principal.aspx");
        }
    }
}