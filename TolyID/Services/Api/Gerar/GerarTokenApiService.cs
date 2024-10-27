
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace TolyID.Services.Api.Gerar
{
    public class GerarTokenApiService:BaseApi
    {
        public struct TokenResponse
        {
            public string token { get; set; }
        }

        public async Task<string> Gerar()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    using StringContent jsonContent = new(
                    JsonSerializer.Serialize(new
                    {
                        email = EmailBaseApi,
                        senha = SenhaBaseApi
                    }),
                    Encoding.UTF8,
                    "application/json");

                    string url = $"http://{UrlBaseApi}:8080/login/token";
                    HttpResponseMessage resposta = await client.PostAsync(url, jsonContent);

                    if (resposta.IsSuccessStatusCode)
                    {
                        string result = await resposta.Content.ReadAsStringAsync();
                        TokenResponse token = JsonSerializer.Deserialize<TokenResponse>(result);
                        return token.token;
                    }
                    else
                    {
                        return "Erro: " + resposta.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"#####################3 {ex.Message}");
                    return ex.Message;
                }
            }
        }
    }
}
