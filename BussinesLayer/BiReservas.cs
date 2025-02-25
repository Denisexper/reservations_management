using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class BiReservas
    {
        Reservas reservasN = new Reservas();
        Habitaciones habitacionesN = new Habitaciones();

        public DataTable ObtenerReservas()
        {
            return reservasN.ObtenerReservas();
        }

        public bool AgregarReserva(int id_reserva, int id_cliente, int id_habitacion, decimal? descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            // Calcular el número de días de la estancia
            int diasEstadia = (checkout - checkin).Days;
            if(diasEstadia == 0)
            {
                diasEstadia = 1;
            }

            int huespedes = habitacionesN.HuespedesPorHabitacion(id_habitacion);

            // Obtener el precio por tipo de habitación
            decimal precioPorNoche = ObtenerPrecioPorHuespedes(huespedes);
            decimal precioTotal = precioPorNoche * diasEstadia;

            // Aplicar descuento si existe
            if (descuento.HasValue)
            {
                if (descuento.Value == 10 || descuento.Value == 25)
                {
                    // Aplica descuento: se hace el cálculo del descuento sobre el precio
                    decimal descuentoAplicado = precioTotal * (descuento.Value / 100);
                    precioTotal -= descuentoAplicado;
                }
                else
            {
                    throw new ArgumentException("El descuento solo puede ser 10% o 25%");
                }
            }
            

            // Llamar a la capa de datos para insertar la reserva en la base de datos
            return reservasN.AgregarReserva(id_reserva, id_cliente, id_habitacion, precioTotal, descuento, checkin, checkout, fecha_registro, id_usuario);
        }

        // Lógica para obtener el precio por habitación
        private decimal ObtenerPrecioPorHuespedes(int huespedes)
        {
            decimal precio = 0;
            if (huespedes <= 2)
            {
                precio = 80M;
            }
            else if (huespedes <= 4)
            {
                precio = 125M;
            }
            else if (huespedes <= 6)
            {
                precio = 150M;
            }
            else if (huespedes <= 8)
            {
                precio = 175M;
            }
            else if (huespedes <= 10)
            {
                precio = 300M;
            }
            else if (huespedes <= 12)
            {
                precio = 325M;
            }
            return precio;
        }

        public bool ModificarReserva(int id_reserva, int id_cliente, int id_habitacion, decimal precio, decimal? descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            return reservasN.ModificarReserva(id_reserva, id_cliente, id_habitacion, precio, descuento, checkin, checkout, fecha_registro, id_usuario);
        }

        public bool EliminarReserva(int id_reserva)
        {
            return reservasN.EliminarReserva(id_reserva);
        }


    }
}
