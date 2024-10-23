using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleTolyID
{
    public class GerarToken
    {
        public static async Task<string> Gerar()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://172.20.10.6:8080/hello";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Lê a resposta diretamente como uma string
                    string result = await response.Content.ReadAsStringAsync();
                    return result; // Retorna a string recebida
                }
                else
                {
                    return "Erro: " + response.StatusCode;
                }
            }
        }
    }
}
