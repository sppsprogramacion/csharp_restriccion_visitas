using CapaDatos;
using Conexion;
using DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public async Task<(bool, string error)> CambiarParentesco(int id, string dataCambiar)
        {
            try
            {             
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataCambiar, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/visitas-internos/cambiar-parentesco?id_visita_interno=" + id, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();

                    var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                    if (dataRespuesta.Affected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se pudo cambiar el parentesco.");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en el cambio de parentesco: {mensaje}");
                }

            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
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
