using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;
using TolyID.MVVM.Models;

namespace TolyID.Services.Api.Ler;

public class LerCapturasApiService : BaseApi
{
    public async Task<List<Captura>> Ler(string token)
    {
        List<Captura> capturas = new();

        try
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://{UrlBaseApi}:8080/capturas/listar";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync(url);

                // Armazenará os ids dos tatus contidos em cada captura
                List<int> tatuIds = new();

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var contentArray = JArray.Parse(JObject.Parse(jsonResponse)["content"].ToString());
                   
                    foreach (var captura in contentArray)
                    {
                        int tatuId = (int)captura["tatu"]["id"];
                        tatuIds.Add(tatuId);
                    }

                    capturas = JsonConvert.DeserializeObject<List<Captura>>(contentArray.ToString());
                }

                int contador = 0;
                foreach (var captura in capturas) 
                {
                    captura.DadosGeraisId = captura.DadosGerais.Id;
                    captura.FichaAnestesicaId = captura.FichaAnestesica.Id;
                    captura.BiometriaId = captura.Biometria.Id;
                    captura.AmostrasId = captura.Amostra.Id;
                    captura.TatuId = tatuIds[contador];
                    contador++;

                    foreach (var parametro in captura.FichaAnestesica.ParametrosFisiologicos)
                    {
                        parametro.FichaAnestesicaId = captura.FichaAnestesicaId;
                    }
                }

                return capturas;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return capturas;
        }
    }
}
