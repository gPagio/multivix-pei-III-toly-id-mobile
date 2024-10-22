using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TolyID.MVVM.Models;
using TolyID.Services.Api;

namespace ConsoleTolyID;
public class CadastrarTatuApi : BaseApiConfiguration
{
    public async void CadastrarTatu(Tatu tatu, string token)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = Configuration["ApiSettings:CadastrarTatuURL"]!;
            var json = JsonConvert.SerializeObject(tatu);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var tokenObject = JObject.Parse(result);
                }
                else
                {
                    Console.WriteLine("Erro: " + response.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao enviar a requisição: " + e.Message);
            }
        }
    }

}
