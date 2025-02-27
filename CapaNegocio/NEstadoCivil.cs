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
    public class NEstadoCivil
    {
        //RETORNAR ESTADO CIVIL TODOS
        public async Task<List<DEstadoCivil>> RetornarListaEstadoCivil()
        {
            IEstadoCivilDao estadoCivilDao = new EstadoCivilDaoImpl();

            List<DEstadoCivil> listaEstadoCivil = await estadoCivilDao.retornarListaEstadoCivil();


            return listaEstadoCivil;
        }
        //FIN RETORNAR ESTADO CIVIL TODOS..................................
    }
}
