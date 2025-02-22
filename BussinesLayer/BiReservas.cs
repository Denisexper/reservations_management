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

        public DataTable ObtenerReservas()
        {
            return reservasN.ObtenerReservas();
        }

        public bool AgregarReserva(int id_reserva, int id_cliente, int id_habitacion, decimal? descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            // Calcular el número de días de la estancia
            int diasEstadia = (checkout - checkin).Days;

            // Obtener el precio por tipo de habitación
            decimal precioPorNoche = ObtenerPrecioPorHabitacion(id_habitacion);
            decimal precioTotal = precioPorNoche * diasEstadia;

            // Aplicar descuento si existe
            if (descuento.HasValue)
            {
                // Aplica descuento: se hace el cálculo del descuento sobre el precio
                decimal descuentoAplicado = (precioTotal / 1.13M) * (descuento.Value / 100);
                precioTotal -= descuentoAplicado;
            }

            // Llamar a la capa de datos para insertar la reserva en la base de datos
            return reservasN.AgregarReserva(id_reserva, id_cliente, id_habitacion, precioTotal, descuento, checkin, checkout, fecha_registro, id_usuario);
        }

        // Lógica para obtener el precio por habitación
        private decimal ObtenerPrecioPorHabitacion(int id_habitacion)
        {
            decimal precio = 0;
            switch (id_habitacion)
            {
                case 2: // Habitación de 3 huéspedes familiar
                    precio = 100M;
                    break;
                case 3: // Habitación de 2 huéspedes simple
                    precio = 80M;
                    break;
                case 4: // Habitación de 4 huésped normal
                    precio = 125M;
                    break;
                case 8: // Habitación de 6 huespedes simple pluss
                    precio = 150M;
                    break;
                case 9: // Habitación de 8 huéspedes familiar largue
                    precio = 175M;
                    break;
                case 10: // habitacion de 10 huespedes grande
                    precio = 300M;
                    break;
                case 11: // habitacion de 12 huespedes extra grande
                    precio = 325M;
                    break;
                default:
                    precio = 100M;
                    break;
            }
            return precio;
        }


    }
}
