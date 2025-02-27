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
    public class OrganismoDaoImpl : IOrganismoDao
    {
        private string url_base = MiConexion.getConexion();

        public Task<DOrganismo> buscarorganismoXId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DOrganismo>> retornarListaOrganismos()
        {

            HttpClient httpClient = new HttpClient();
            List<DOrganismo> listaOrganismos = new List<DOrganismo>();

            var httpResponse = await httpClient.GetAsync(url_base + "/organismos/todos");

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                listaOrganismos = JsonConvert.DeserializeObject<List<DOrganismo>>(content);

            }

            return listaOrganismos;
        }
    }
}
