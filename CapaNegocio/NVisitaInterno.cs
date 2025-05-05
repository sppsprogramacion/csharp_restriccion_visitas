using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NVisitaInterno
    {
        

        //RETORNAR PARENTESCOS POR CIUDADANO
        public async Task<List<DVisitaInterno>> RetornarListaParentescos(int idCiudadano)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            List<DVisitaInterno> listaParentescos = await visitaInternoDao.RetornarParentescosXCiudadano(idCiudadano);


            return listaParentescos;
        }
        //FIN RETORNAR PARENTESCOS POR CIUDADANO..................................

        //CAMBIAR PARENTESCO
        public async Task<(bool, string error)> CambiarParentesco(int id, string prohibicioVisita)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            (bool visitaInternoResponse, string error) = await visitaInternoDao.CambiarParentesco(id, prohibicioVisita);

            return (visitaInternoResponse, error); ;
        }
        //FIN CAMBIAR PARENTESCO..................................

        //PROHIBIR PARENTESCO
        public async Task<(bool, string error)> ProhibirParentesco(int id, string prohibicionParentesco)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            (bool visitaInternoResponse, string error) = await visitaInternoDao.ProhibirParentesco(id, prohibicionParentesco);

            return (visitaInternoResponse, error); ;
        }
        //FIN PROHIBIR PARENTESCO..................................
    }
}
