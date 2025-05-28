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
    public class ProhibisionVisitaAnticipadaDaoImpl : IProhibicionVisitaAnticipadaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public Task<(DProhibicionAnticipada, string error)> CrearProhivisionAnticipada(string prohibicionVisita)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string error)> EditarProhibicionVisitaAnticipada(int id, string prohibicionVisita)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string error)> LevantarProhibicionAnticipada(int id, string dataLevantar)
        {
            throw new NotImplementedException();
        }
        public Task<(DProhibicionAnticipada, string error)> BuscarProhibicionAnticipadaXId(int idProhibicionvisita)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<DProhibicionAnticipada>, string error)> RetornarProhibicionesAnticipadasXApellido(string apellido)
        {
            List<DProhibicionAnticipada> listaProhibiciones = new List<DProhibicionAnticipada>();

            try
            {
                
                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/ciudadanos/buscarlista-xapellido?apellido=" + apellido);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaProhibiciones = JsonConvert.DeserializeObject<List<DProhibicionAnticipada>>(content);
                    return (listaProhibiciones, null);
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
