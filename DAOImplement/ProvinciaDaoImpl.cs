using CapaDatos;
using Conexion;
using DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class ProvinciaDaoImpl : IProvinciaDao
    {
        private string url_base = MiConexion.getConexion();

        public DProvincia buscarProvinciaXId(int id)
        {
            throw new NotImplementedException();
        }

        public int crearProvincia(DProvincia provincia)
        {
            throw new NotImplementedException();
        }

        public int editarProvincia(DProvincia provincia)
        {
            throw new NotImplementedException();
        }

        async public Task<List<DProvincia>> retornarListaProvinciasXPais(string id_pais)
        {
            HttpClient httpClient = new HttpClient();
            List<DProvincia> listaProvincias = new List<DProvincia>();

            var httpResponse = await httpClient.GetAsync(url_base + "/provincias/buscar-xpais?id_pais=" + id_pais);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                listaProvincias = JsonConvert.DeserializeObject<List<DProvincia>>(content);

            }

            return listaProvincias;
        }
    }
}
