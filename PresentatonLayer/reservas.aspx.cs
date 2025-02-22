using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentatonLayer
{
    public partial class reservas : System.Web.UI.Page
    {
        BiReservas negocioReserva = new BiReservas();
        BiUsuarios negocioUsuario = new BiUsuarios();
        BiCliente negocioCliente = new BiCliente();
        BiHabitaciones negocioHabitacion = new BiHabitaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReservas();
                CargarClientes();
                CargarUsuarios();
                CargarHabitaciones();
            }
        }

        protected void CargarReservas()
        {
            gvReservas.DataSource = negocioReserva.ObtenerReservas();
            gvReservas.DataBind();
        }

        protected void CargarClientes()
        {
            ddlCliente.DataSource = negocioCliente.obtenerClientes();
            ddlCliente.DataTextField = "nombre";
            ddlCliente.DataValueField = "id_cliente";
            ddlCliente.DataBind();
        }

        protected void CargarUsuarios()
        {
            ddlUsuario.DataSource = negocioUsuario.ObtenerUsuarios();
            ddlUsuario.DataTextField = "usuario";
            ddlUsuario.DataValueField = "id";
            ddlUsuario.DataBind();
        }

        protected void CargarHabitaciones()
        {
            ddlHabitacion.DataSource = negocioHabitacion.obtenerHabitaciones();
            ddlHabitacion.DataTextField = "descripcion";
            ddlHabitacion.DataValueField = "id_habitaciones";
            ddlHabitacion.DataBind();
        }

        protected void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            
                try
                {
                    // Obtener los valores desde los controles del formulario
                    int id_reserva = Convert.ToInt32(txtIdReserva.Text);  // ID Reserva
                    int id_cliente = int.Parse(ddlCliente.SelectedValue);  // Cliente
                    int id_habitaciones = int.Parse(ddlHabitacion.SelectedValue);  // Habitación

                    // Obtener las fechas y el descuento
                    DateTime checkin = Convert.ToDateTime(txtCheckIn.Text);
                    DateTime checkout = Convert.ToDateTime(txtCheckOut.Text);
                    decimal? descuento = string.IsNullOrEmpty(txtDescuento.Text) ? (decimal?)null : Convert.ToDecimal(txtDescuento.Text);
                    string fecha_registro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Fecha de registro
                    int id_usuario = int.Parse(ddlUsuario.SelectedValue);  // Usuario que registra

                   
                    bool reservaAgregada = negocioReserva.AgregarReserva(id_reserva, id_cliente, id_habitaciones, descuento, checkin, checkout, fecha_registro, id_usuario);

                    
                    if (reservaAgregada)
                    {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                          "Swal.fire('¡Éxito!', 'La reserva se ha guardado correctamente', 'success');", true);
                        gvReservas.EditIndex = -1;
                        CargarReservas();
                    }
                    else
                    {
                        // Mostrar mensaje de error con SweetAlert
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Hubo un error al agregar la reserva.', 'error');", true);
                    }
                }
                catch (Exception ex)
                {
                    // Mostrar mensaje de error con SweetAlert en caso de excepciones
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Error: " + ex.Message + "', 'error');", true);
                }


        }
    }
}