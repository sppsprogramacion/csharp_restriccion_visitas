using CapaDatos;
using DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace DAOImplement
{
    public class NovedadCiudadanoDaoImpl : INovedadCiudadanoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public Task<(DNovedadCiudadano, string error)> BuscarNovedadCiudadanoXId(int idNovedad)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<DNovedadCiudadano>, string error)> RetornarNovedadesCiudadanoXCiudadano(int idCiudadano)
        {
            List<DNovedadCiudadano> listaNovedades = new List<DNovedadCiudadano>();

            try
            {
                
                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/novedades-ciudadano/lista-xciudadano?id_ciudadano=" + idCiudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaNovedades = JsonConvert.DeserializeObject<List<DNovedadCiudadano>>(content);
                    return (listaNovedades, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error en la busqueda: {mensaje}");
                }
                
            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (null, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (null, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }

        }
    }
}
