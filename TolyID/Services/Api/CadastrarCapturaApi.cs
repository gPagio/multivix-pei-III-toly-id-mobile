using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TolyID.DTO;
using TolyID.MVVM.Models;

namespace TolyID.Services.Api
{
    public class CadastrarCapturaApi
    {
        public struct RespostaCaptura
        {
            public int Id { get; set; }
            public Usuario Usuario { get; set; }
            public Tatu Tatu { get; set; }
            public DadosGerais DadosGerais { get; set; }
            public FichaAnestesica FichaAnestesica { get; set; }
            public Biometria Biometria { get; set; }
            public Amostras Amostra { get; set; }
        }

        public async Task CadastrarCaptura(CapturaDTO capturaDTO, Captura captura)
        {
            try
            {
                var bancotatu = new TatuService();
                Tatu tatu = await bancotatu.GetTatu(captura.TatuId);

                if (tatu.IdAPI == null)
                {
                    Debug.WriteLine("Tatu sem ID API.");
                    return;
                }

                string url = $"http://172.20.10.6:8080/capturas/cadastrar/{tatu.IdAPI}";
                string token = await GerarToken.Gerar();

                if (string.IsNullOrEmpty(token))
                {
                    Debug.WriteLine("Token inválido.");
                    return;
                }

                var content = new StringContent(JsonConvert.SerializeObject(capturaDTO), Encoding.UTF8, "application/json");
                Debug.WriteLine(JsonConvert.SerializeObject(capturaDTO));

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        RespostaCaptura res = JsonConvert.DeserializeObject<RespostaCaptura>(jsonResponse);

                        captura.IdAPI = res.Id;
                        captura.FoiEnviadoParaApi = true;
                        var banco = new CapturaService();
                        await banco.AtualizaCaptura(captura);
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
