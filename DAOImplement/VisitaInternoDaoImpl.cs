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
    public class VisitaInternoDaoImpl : IVisitaInternoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public Task<HttpResponseMessage> AnularParentesco(int id, string dataAnular)
        {
            throw new NotImplementedException();
        }

        public Task<DVisitaInterno> BuscarParentescoXId(int idProhibicionvisita)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> CambiarParentesco(int id, string dataCambiar)
        {
            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataCambiar, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/visitas-internos/cambiar-parentesco?id_visita_interno=" + id, content);


                return httpResponse;

            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                throw new Exception($"Error al realizar la solicitud: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON
                throw new Exception($"Error al serializar/deserializar JSON: {jsonException.Message}");
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro tipo de excepción
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                throw new Exception($"Ocurrió un error inesperado: {ex.Message}");
            }
        }

        public Task<HttpResponseMessage> CrearParentesco(string visitaInterno)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DVisitaInterno>> RetornarParentescosXCiudadano(int idCiudadano)
        {
            List<DVisitaInterno> listaParentescos = new List<DVisitaInterno>();

            var httpResponse = await this.httpClient.GetAsync(url_base + "/visitas-internos/buscarlista-xciudadano?id_ciudadano=" + idCiudadano);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                listaParentescos = JsonConvert.DeserializeObject<List<DVisitaInterno>>(content);

            }
            var objeto = listaParentescos;

            return listaParentescos;
        }

        public Task<List<DVisitaInterno>> RetornarParentescosXInterno(int idInterno)
        {
            throw new NotImplementedException();
        }

        
    }
}
