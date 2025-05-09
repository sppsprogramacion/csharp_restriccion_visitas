using CapaDatos;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class ExcepcionIngresoVisitaDaoImpl : IExcepcionIngresoVisitaDao
    {
        public Task<(DExcepcionIngresoVisita, string error)> BuscarExcepcionIngresoVisitaXId(int idExcepcionIngresoVisita)
        {
            throw new NotImplementedException();
        }

        public Task<(DExcepcionIngresoVisita, string error)> CrearExcepcionIngresoVisita(string excepcionIngresoVisita)
        {
            throw new NotImplementedException();
        }

        public Task<(List<DExcepcionIngresoVisita>, string error)> RetornarExcepcionesIngresoXCiudadano(int idCiudadano)
        {
            throw new NotImplementedException();
        }
    }
}
