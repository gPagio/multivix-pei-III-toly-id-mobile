using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TolyID.MVVM.Models;


namespace ConsoleTolyID
{
    public class GerarToken
    {
        public async Task<string> Gerar()
        {
            using (HttpClient client = new HttpClient())
            {
                Usuario usuario = new()
                {
                    //Email = Configuration["ApiSettings:usuario"],
                    //Senha = Configuration["ApiSettings:senha"]
                    Email = "guilherme@toly.com",
                    Senha = "123456"
                };


                //string url = Configuration["ApiSettings:TokenUrl"]!;
                string url = "http://localhost:8080/login/token";
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
                        return "Erro:"+ response.StatusCode;
                    }
                }
                catch (Exception e)
                {
                    return "Erro ao enviar a requisição: " + e.Message;
                }
            }
        }
    }
}
