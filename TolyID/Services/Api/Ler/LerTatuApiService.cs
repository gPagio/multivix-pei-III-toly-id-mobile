using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using TolyID.MVVM.Models;

namespace TolyID.Services.Api.Ler;

public class LerTatuApiService : BaseApi
{
    public async Task<List<Tatu>> GetTatus(string token)
    {
        List<Tatu> tatus = new();

        using (HttpClient client = new HttpClient())
        {
            string url = $"http://{UrlBaseApi}:8080/tatus/listar";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage resposta = await client.GetAsync(url);

            List<int> tatuIdsApi = new();

            if (resposta.IsSuccessStatusCode)
            {
                var jsonResponse = await resposta.Content.ReadAsStringAsync();
                var contentArray = JArray.Parse(JObject.Parse(jsonResponse)["content"].ToString());
                  
                foreach (var captura in contentArray)
                {
                    int tatuId = (int)captura["id"];
                    tatuIdsApi.Add(tatuId);
                }

                tatus = JsonConvert.DeserializeObject<List<Tatu>>(contentArray.ToString());
            }
            else
            {
                throw new Exception($"Erro de conexão: {resposta.StatusCode}");
            }

            int contador = 0;
            foreach (var tatu in tatus) 
            {
                tatu.IdAPI = tatuIdsApi[contador];
                contador++;
            }

            return tatus;
        }
    }
}
