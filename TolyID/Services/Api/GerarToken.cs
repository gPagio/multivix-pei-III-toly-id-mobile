using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TolyID.MVVM.Models;
using TolyID.Services.Api;

namespace ConsoleTolyID
{
    public class GerarToken : BaseApiConfiguration
    {
        public async Task<string> Gerar()
        {
            using (HttpClient client = new HttpClient())
            {
                Usuario usuario = new()
                {
                    Email = Configuration["ApiSettings:usuario"],
                    Senha = Configuration["ApiSettings:senha"]
                };


                string url = Configuration["ApiSettings:TokenUrl"]!;
                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var tokenObject = JObject.Parse(result);
                        return tokenObject["token"]?.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Erro: " + response.StatusCode);
                        return null!;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao enviar a requisição: " + e.Message);
                    return null!;
                }
            }
        }
    }
}
