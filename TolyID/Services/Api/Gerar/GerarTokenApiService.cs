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
            TokenResponse token = new();

            // Reutilização do HttpClient, considere usar uma instância estática ou injetá-la
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(10); // Define um timeout de 10 segundos
             
                var requestBody = new
                {
                    email = EmailBaseApi,
                    senha = SenhaBaseApi
                };

                using StringContent jsonContent = new(
                      JsonSerializer.Serialize(requestBody),
                      Encoding.UTF8,
                      "application/json");

                string url = $"http://{UrlBaseApi}:8080/login/token";

                HttpResponseMessage resposta = await client.PostAsync(url, jsonContent);

                if (resposta.IsSuccessStatusCode)
                {
                    string result = await resposta.Content.ReadAsStringAsync();
                    token = JsonSerializer.Deserialize<TokenResponse>(result);
                    return token.token;
                }
                else
                {
                    throw new Exception($"Erro de conexão: {resposta.StatusCode}");
                }
            }
        }
    }
}
