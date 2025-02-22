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
    public partial class huespedes : System.Web.UI.Page
    {
        BiHabitaciones negocioHabitaciones = new BiHabitaciones();
        BiUsuarios negociousuarios = new BiUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) //si no hay sesion
            {
                Response.Redirect("index.aspx"); //lo mandamos al login
            }

            if (!IsPostBack)
            {
                CargarHabitaciones();
                CargarUsuarios();
            }
        }

        protected void CargarUsuarios()
        {
            ddlUsuario.DataSource = negociousuarios.ObtenerUsuarios();
            ddlUsuario.DataTextField = "usuario";
            ddlUsuario.DataValueField = "id";
            ddlUsuario.DataBind();
        }

        protected void CargarHabitaciones()
        {
            GridView1.DataSource = negocioHabitaciones.obtenerHabitaciones();
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //validar campos vacios
            if (string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtdescripcion.Text) ||
                string.IsNullOrEmpty(txthuespedes.Text))
            { 
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                    "Swal.fire('Error', 'Todos los campos son obligatorios. Por favor, complete la información.', 'warning');", true);
                return;
            }

            int numero = Convert.ToInt32(txtnumero.Text);
            string descripcion = txtdescripcion.Text;
            int huespedes = Convert.ToInt32(txthuespedes.Text);
            int idUsuario = int.Parse(ddlUsuario.SelectedValue);

            



            bool exito = negocioHabitaciones.AgregarHabitacion(numero, descripcion, huespedes, idUsuario);
            if (exito)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('¡Éxito!', 'La habitación se ha guardado correctamente', 'success');", true);

                CargarHabitaciones();

                //limpiar texbox despues de guardar informacion
                txtnumero.Text = "";
                txtdescripcion.Text = "";
                txthuespedes.Text = "";
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('Error', 'Error guardando habitacion o el Usuario no existe', 'error');", true);

                
            }
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            CargarHabitaciones();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            GridViewRow crow = GridView1.Rows[e.RowIndex];

            
            int numero = int.Parse((crow.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            string descripcion = (crow.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            int huespedes = int.Parse((crow.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            int idUsuario = int.Parse((crow.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            

            if (!negocioHabitaciones.UsuarioExiste(idUsuario))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('Error', 'El usuario no existe', 'error');", true);
                return;
            }

            if (negocioHabitaciones.ModificarHabitacion(id, numero, descripcion, huespedes, idUsuario))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('¡Éxito!', 'La habitación se ha acctualizado correctamente', 'success');", true);

                GridView1.EditIndex = -1;  
                CargarHabitaciones();  
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('Error', 'Hubo un problema al actualizar la habitación', 'error');", true);
                return;
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            CargarHabitaciones();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            if (negocioHabitaciones.EliminarHabitacion(id))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('¡Éxito!', 'La habitación se ha eliminado correctamente', 'success');", true);

                CargarHabitaciones();  // Recarga el GridView
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('Error', 'Hubo un problema al eliminar la habitación', 'error');", true);
                return;
            }
           
        }

        
    }
}