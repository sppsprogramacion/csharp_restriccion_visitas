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
    public class SexoDaoImpl : ISexoDao
    {
        private string url_base = MiConexion.getConexion();

        public DSexo buscarSexoXId(int id)
        {
            throw new NotImplementedException();
        }

        public int crearSexo(DCiudadano usuario)
        {
            throw new NotImplementedException();
        }

        public int editarSexo(DCiudadano usuario)
        {
            throw new NotImplementedException();
        }

        async public Task<List<DSexo>> retornarListaSexo()
        {
            HttpClient httpClient = new HttpClient();
            List<DSexo> listaSexo = new List<DSexo>();

            var httpResponse = await httpClient.GetAsync(url_base + "/sexo");
            
            if (httpResponse.IsSuccessStatusCode)
            {                
                var content = await httpResponse.Content.ReadAsStringAsync();
                listaSexo = JsonConvert.DeserializeObject<List<DSexo>>(content);

            }

            return listaSexo;
        }
    }
}
