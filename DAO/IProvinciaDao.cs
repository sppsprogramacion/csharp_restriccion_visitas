using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IProvinciaDao
    {
        int crearProvincia(DProvincia provincia);

        int editarProvincia(DProvincia provincia);

        DProvincia buscarProvinciaXId(int id);

        Task<List<DProvincia>> retornarListaProvinciasXPais(string id_pais);
    }
}
