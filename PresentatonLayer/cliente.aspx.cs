using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentatonLayer
{
    public partial class cliente : System.Web.UI.Page
    {
        BiCliente negocioCliente = new BiCliente();
        BiUsuarios negocioUsuario = new BiUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) //si no hay sesion
            {
                Response.Redirect("index.aspx"); //lo mandamos al login
            }
            if (!IsPostBack)
            {
                CargarClientes();
                CargarUsuarios();
            }
        }

        protected void CargarClientes()
        {
            dvClientes.DataSource = negocioCliente.obtenerClientes();
            dvClientes.DataBind();
        }

        protected void CargarUsuarios()
        {
            dlusuario.DataSource = negocioUsuario.ObtenerUsuarios();
            dlusuario.DataTextField = "usuario";
            dlusuario.DataValueField = "id";
            dlusuario.DataBind();
        }

        protected void dvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dvClientes.EditIndex = e.NewEditIndex;
            CargarClientes();
        }

        protected void dvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(dvClientes.DataKeys[e.RowIndex].Value);
            GridViewRow crow = dvClientes.Rows[e.RowIndex];

            string nombre = (crow.Cells[1].Controls[0] as TextBox).Text;
            int dui = int.Parse((crow.Cells[2].Controls[0] as TextBox).Text);
            int telefono = int.Parse((crow.Cells[3].Controls[0] as TextBox).Text);
            string correo = (crow.Cells[4].Controls[0] as TextBox).Text;
            string departamento = (crow.Cells[5].Controls[0] as TextBox).Text;
            DateTime fecha_registro = DateTime.Parse((crow.Cells[6].Controls[0] as TextBox).Text);
            int id_usuario = int.Parse((crow.Cells[7].Controls[0] as TextBox).Text);

            if (negocioCliente.ModificarCliente(id, nombre, dui, telefono, correo, departamento, fecha_registro, id_usuario))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('¡Éxito!', 'El cliente se ha acctualizado correctamente', 'success');", true);

                dvClientes.EditIndex = -1;
                CargarClientes();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('Error', 'Hubo un problema al actualizar el cliente', 'error');", true);
                return;
            }
        }

        protected void dvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dvClientes.EditIndex = -1;
            CargarClientes();
        }

        protected void dvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(dvClientes.DataKeys[e.RowIndex].Value);
            if (negocioCliente.EliminarCliente(id))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('¡Éxito!', 'El cliente se ha eliminado correctamente', 'success');", true);

                CargarClientes();  // Recarga el GridView
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('Error', 'Hubo un problema al eliminar el cliente', 'error');", true);
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtdui.Text) ||
                string.IsNullOrEmpty(txtdepartamento.Text) || string.IsNullOrEmpty(txtcorreo.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                    "Swal.fire('Error', 'Todos los campos son obligatorios. Por favor, complete la información.', 'warning');", true);
                return;
            }

            string nombre = txtnombre.Text;
            int dui = Convert.ToInt32(txtdui.Text);
            int telefono = Convert.ToInt32(txttelefono.Text);
            string correo = txtcorreo.Text;
            string departamento = txtdepartamento.Text;
            DateTime fecha_registro = DateTime.Parse(txtFechaRegistro.Text);
            int id_usuario = int.Parse(dlusuario.SelectedValue);

            bool exito = negocioCliente.AgregarCliente(nombre, dui, telefono, correo, departamento, fecha_registro, id_usuario);
            if (exito)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('¡Éxito!', 'El cliente se ha guardado correctamente', 'success');", true);

                CargarClientes();

                txtnombre.Text = "";
                txtdui.Text = "";
                txttelefono.Text = "";
                txtcorreo.Text = "";
                txtdepartamento.Text = "";
                txtFechaRegistro.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
                              "Swal.fire('Error', 'Error guardando Cliente', 'error');", true);
            }

        }
    }
}