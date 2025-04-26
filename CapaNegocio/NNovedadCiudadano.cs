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
    public class NNovedadCiudadano
    {
        //RETORNAR NOVEDADES DEL CIUDADANO POR CIUDADANO
        public async Task<(List<DNovedadCiudadano>, string error)> RetornarListaNovedadesCiudadano(int idCiudadano)
        {
            INovedadCiudadanoDao novedadCiudadanoDao = new NovedadCiudadanoDaoImpl();

            (List<DNovedadCiudadano> listaNovedadesCiudadano, string errorResponse) = await novedadCiudadanoDao.RetornarNovedadesCiudadanoXCiudadano(idCiudadano);


            return (listaNovedadesCiudadano, errorResponse);
        }
        //FIN RETORNAR NOVEDADES DEL CIUDADANO POR CIUDADANO..................................
    }
}
