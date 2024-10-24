using System.Text;
using System.Text.Json;

namespace TolyID.Services.Api;

public class GerarToken
{
    public struct TokenResponse
    {
        public string token { get; set; } // Corrigido para 'tokenString'
    }

    public static async Task<string> Gerar()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    email = "guilherme@toly.com",
                    senha = "123456"
                }),
                Encoding.UTF8,
                "application/json");

                string url = "http://172.20.10.6:8080/login/token";
                HttpResponseMessage resposta = await client.PostAsync(url, jsonContent);

                if (resposta.IsSuccessStatusCode)
                {
                    // Lê o conteúdo da resposta e deserializa para a struct TokenResponse
                    string result = await resposta.Content.ReadAsStringAsync();
                    TokenResponse token = JsonSerializer.Deserialize<TokenResponse>(result);

                    // Retorna a propriedade tokenString
                    return token.token;
                }
                else
                {
                    return "Erro: " + resposta.StatusCode;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
