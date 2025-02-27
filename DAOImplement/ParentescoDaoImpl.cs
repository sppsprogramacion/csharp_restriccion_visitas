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
    public class ParentescoDaoImpl : IParentescoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public Task<DParentesco> BuscarParentescoXId(int idParentesco)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DParentesco>> RetornarParentescos()
        {
            List<DParentesco> listaParentescos = new List<DParentesco>();

            var httpResponse = await this.httpClient.GetAsync(url_base + "/parentescos/todos");

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                listaParentescos = JsonConvert.DeserializeObject<List<DParentesco>>(content);

            }
            var objeto = listaParentescos;

            return listaParentescos;
        }
    }
}
