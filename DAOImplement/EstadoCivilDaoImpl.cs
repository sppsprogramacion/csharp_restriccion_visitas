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
    public class EstadoCivilDaoImpl : IEstadoCivilDao
    {
        private string url_base = MiConexion.getConexion();

        public DEstadoCivil buscarEstadoCivilXId(int id)
        {
            throw new NotImplementedException();
        }

        async public Task<List<DEstadoCivil>> retornarListaEstadoCivil()
        {
            HttpClient httpClient = new HttpClient();
            List<DEstadoCivil> listaEstadoCivil = new List<DEstadoCivil>();

            var httpResponse = await httpClient.GetAsync(url_base + "/estado-civil/todos");

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                listaEstadoCivil = JsonConvert.DeserializeObject<List<DEstadoCivil>>(content);

            }

            return listaEstadoCivil;
        }
    }
}
