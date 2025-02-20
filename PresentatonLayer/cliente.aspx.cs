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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        protected void CargarClientes()
        {
            dvClientes.DataSource = negocioCliente.obtenerClientes();
            dvClientes.DataBind();
        }   


    }
}