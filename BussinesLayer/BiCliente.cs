using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class BiCliente
    {

        Cliente clientesN = new Cliente();

        public DataTable obtenerClientes()
        {
            return clientesN.ObtenerClientes();
        }

        public bool AgregarCliente(string nombre, int dui, int telefono, string correo, string departemento, DateTime fecha_registro, int id_usuario)
        {
            return clientesN.AgregarCliente(nombre, dui, telefono, correo, departemento, fecha_registro, id_usuario);
        }

        public bool ModificarCliente(int id, string nombre, int dui, int telefono, string correo, string departemento, DateTime fecha_registro, int id_usuario)
        {
            return clientesN.ModificarCliente(id, nombre, dui, telefono, correo, departemento, fecha_registro, id_usuario);
        }

        public bool EliminarCliente(int id)
        {
            return clientesN.EliminarCliente(id);
        }
    }
}
