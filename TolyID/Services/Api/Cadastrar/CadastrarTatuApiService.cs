using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using TolyID.DTO;
using TolyID.MVVM.Models;


namespace TolyID.Services.Api.Cadastrar
{
    public class CadastrarTatuApiService : BaseApi
    {
        public struct RespostaTatu
        {
            public int Id { get; set; }
            public string IdentificacaoAnimal { get; set; }
            public int NumeroMicrochip { get; set; }
        }

        public async Task Cadastrar(Tatu tatu, string token)
        {
            TatuDTO tatuDTO = new(tatu);
            try
            {
                string url = $"http://{UrlBaseApi}:8080/tatus/cadastrar";


                if (string.IsNullOrEmpty(token))
                {
                    Debug.WriteLine("Token inválido.");
                    return;
                }

                var content = new StringContent(JsonConvert.SerializeObject(tatuDTO), Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        RespostaTatu res = JsonConvert.DeserializeObject<RespostaTatu>(jsonResponse);

                        tatu.FoiEnviadoParaApi = true;
                        tatu.IdAPI = res.Id;

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
                Debug.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
