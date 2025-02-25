using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class BiHabitaciones
    {
        Habitaciones habitacionesN = new Habitaciones();

        public DataTable obtenerHabitaciones()
        {
            return habitacionesN.ObtenerHabitaciones();
        }

        public bool AgregarHabitacion(int numero, string descripcion, int huespedes, int idUsuario)
        {
            //validar si el usuario existe
            if (!habitacionesN.UsuarioExiste(idUsuario))
            {
                return false;
            }

            return habitacionesN.AgregarHabitacion(numero, descripcion, huespedes, idUsuario);
        }

        public bool ModificarHabitacion (int id, int numero, string descripcion, int huespedes, int idUsuario)
        {
            return habitacionesN.ModificarHabitacion(id, numero, descripcion, huespedes, idUsuario);
        }

        public bool EliminarHabitacion (int id)
        {
            return habitacionesN.EliminarHabitacion(id);
        }

        public bool UsuarioExiste(int idUsuario)
        {
            return habitacionesN.UsuarioExiste(idUsuario);
        }

        //prueba para obtener nombre del usuario y no no guardar el id
        public DataTable ObtenerNombre()
        {
            return habitacionesN.ObtenerNombre();
        }


    }
}
