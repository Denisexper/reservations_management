using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BussinesLayer
{
    
    public class obtenerReserva
    {
        obtenerReservas obtenerRes = new obtenerReservas();
        public DataTable ObtenerReservaPorCodigo(string codigoReserva)
        {
            return obtenerRes.ObtenerReservaPorCodigo(codigoReserva);
        }
    }
}
