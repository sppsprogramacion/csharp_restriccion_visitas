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
    public class NParentesco
    {
        //RETORNAR PARENTESCOS TODOS
        public async Task<List<DParentesco>> RetornarListaParentescos()
        {
            IParentescoDao parentescoDao = new ParentescoDaoImpl();

            List<DParentesco> listaParentescos = await parentescoDao.RetornarParentescos();


            return listaParentescos;
        }
        //FIN RETORNAR PARENTESCOS TODOS..................................
    }
}
