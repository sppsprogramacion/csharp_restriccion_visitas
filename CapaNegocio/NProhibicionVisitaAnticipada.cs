using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NProhibicionVisitaAnticipada
    {
        //RETORNAR TODOS
        public async Task<(List<DProhibicionAnticipada>, string)> ListaProhibicionesTodas()
        {
            IProhibicionVisitaAnticipadaDao prohibicionAnticipadaDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (List<DProhibicionAnticipada> listaProhibiciones, string error) = await prohibicionAnticipadaDao.ListaProhibicionesTodas();


            return (listaProhibiciones, error);
        }
        //FIN RETORNAR TODOS..................................

        
        //RETORNAR CIUDADANOS X APELLIDO
        public async Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesXApellido(string apellido)
        {
            IProhibicionVisitaAnticipadaDao prohibicionAnticipadaDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (List<DProhibicionAnticipada> listaProhibiciones, string error) = await prohibicionAnticipadaDao.ListaProhibicionesAnticipadasXApellido(apellido);

            return (listaProhibiciones, error);
        }
        //FIN RETORNAR CIUDADANOS X APELLIDO..................................
    }
}
