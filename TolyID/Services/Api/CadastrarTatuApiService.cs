using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using TolyID.MVVM.Models;

namespace TolyID.Services.Api
{
    public class CadastrarTatuApiService
    {
        public async Task Cadastrar(Tatu tatu)
        {
            try
            {
                string url = "http://172.20.10.6:8080/tatus/cadastrar";
                string token = await GerarToken.Gerar();

                if (string.IsNullOrEmpty(token))
                {
                    Debug.WriteLine("Token inválido.");
                    return;
                }

                var content = new StringContent(JsonConvert.SerializeObject(tatu), Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        tatu.FoiEnviadoParaApi = true;
                        var banco = new TatuService();
                        await banco.AtualizaTatu(tatu);
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine($"Erro: {response.StatusCode} - {errorMessage}");
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
