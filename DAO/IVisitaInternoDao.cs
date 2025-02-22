using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IVisitaInternoDao
    {
        Task<HttpResponseMessage> CrearParentesco(string visitaInterno);

        Task<HttpResponseMessage> CambiarParentesco(int id, string dataCambiar);

        Task<HttpResponseMessage> AnularParentesco(int id, string dataAnular);

        Task<DVisitaInterno> BuscarParentescoXId(int idProhibicionvisita);

        Task<List<DVisitaInterno>> RetornarParentescosXCiudadano(int idCiudadano);

        Task<List<DVisitaInterno>> RetornarParentescosXInterno(int idInterno);
    }
}
