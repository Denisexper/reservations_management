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
            if (Session["Usuario"] == null) //si no hay sesion
            {
                Response.Redirect("index.aspx"); //lo mandamos al login
            }
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
            if (string.IsNullOrEmpty(txtIdReserva.Text) || string.IsNullOrEmpty(txtCheckIn.Text) ||
            string.IsNullOrEmpty(txtCheckOut.Text) || string.IsNullOrEmpty(txtFechaRegistro.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                    "Swal.fire('Error', 'Algunos campos son obligatorios. Por favor, complete la información.', 'warning');", true);
                return;
            }


            int id_reserva = Convert.ToInt32(txtIdReserva.Text);
            int id_cliente = int.Parse(ddlCliente.SelectedValue);
            int id_habitaciones = int.Parse(ddlHabitacion.SelectedValue);
            DateTime checkin = Convert.ToDateTime(txtCheckIn.Text);
            DateTime checkout = Convert.ToDateTime(txtCheckOut.Text);
            decimal? descuento = null;
            if (!string.IsNullOrEmpty(txtDescuento.Text))
            {
                descuento = Convert.ToDecimal(txtDescuento.Text);
            }
            string fecha_registro = DateTime.Now.ToString("yyyy-MM-dd");                                                                         // Fecha de registro
            int id_usuario = int.Parse(ddlUsuario.SelectedValue);


            bool reservaAgregada = negocioReserva.AgregarReserva(id_reserva, id_cliente, id_habitaciones, descuento, checkin, checkout, fecha_registro, id_usuario);


            if (reservaAgregada)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                      "Swal.fire('¡Éxito!', 'La habitación se ha guardado correctamente', 'success');", true);

                CargarReservas();

                txtIdReserva.Text = "";
                txtCheckIn.Text = "";
                txtCheckOut.Text = "";
                txtDescuento.Text = "";
                txtFechaRegistro.Text = "";
            }
            else
            {
                //esto era lo que me daba error, el scrip de js estaba malo
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                      "Swal.fire('Error', 'Error guardando habitacion o el Usuario no existe', 'error');", true);
            }


        }

        protected void gvReservas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvReservas.EditIndex = e.NewEditIndex;
            CargarReservas();
        }

        protected void gvReservas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvReservas.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = gvReservas.Rows[e.RowIndex];

            int id_reserva = Convert.ToInt32((row.Cells[0].Controls[0] as TextBox).Text);
            int id_cliente = Convert.ToInt32((row.Cells[1].Controls[0] as TextBox).Text);
            int id_habitacion = Convert.ToInt32((row.Cells[2].Controls[0] as TextBox).Text);
            decimal precio = Convert.ToDecimal((row.Cells[3].Controls[0] as TextBox).Text);
            decimal? descuento = null;
            if (!string.IsNullOrEmpty((row.Cells[4].Controls[0] as TextBox).Text))
            {
                descuento = Convert.ToDecimal((row.Cells[4].Controls[0] as TextBox).Text);
            }
            DateTime checkin = Convert.ToDateTime((row.Cells[5].Controls[0] as TextBox).Text);
            DateTime checkout = Convert.ToDateTime((row.Cells[6].Controls[0] as TextBox).Text);
            string fecha_registro = (row.Cells[7].Controls[0] as TextBox).Text;
            int id_usuario = Convert.ToInt32((row.Cells[8].Controls[0] as TextBox).Text);

            if (negocioReserva.ModificarReserva(id_reserva, id_cliente, id_habitacion, precio, descuento, checkin, checkout, fecha_registro, id_usuario))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                      "Swal.fire('¡Éxito!', 'La habitación se ha actualizado correctamente', 'success');", true);
                gvReservas.EditIndex = -1;
                CargarReservas();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                      "Swal.fire('Error', 'Error actualizando habitación', 'error');", true);
            }
        }

        protected void gvReservas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvReservas.EditIndex = -1;
            CargarReservas();
        }

        protected void gvReservas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvReservas.DataKeys[e.RowIndex].Value.ToString());
            if (negocioReserva.EliminarReserva(id))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                      "Swal.fire('¡Éxito!', 'La habitación se ha eliminado correctamente', 'success');", true);
                CargarReservas();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                      "Swal.fire('Error', 'Error eliminando habitación', 'error');", true);
            }
        }
    }
}