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
        Task<(bool, string error)> CambiarParentesco(int id, string dataCambiar);

        Task<(bool, string error)> AnularParentesco(int id, string dataAnular);

        Task<(bool, string error)> ProhibirParentesco(int id, string dataProhibir);

        Task<(bool, string error)> LevantarProhibicionParentesco(int id, string dataLevantar);

        Task<DVisitaInterno> BuscarParentescoXId(int idProhibicionvisita);

        Task<List<DVisitaInterno>> RetornarParentescosXCiudadano(int idCiudadano);

        Task<List<DVisitaInterno>> RetornarParentescosXInterno(int idInterno);
    }
}
