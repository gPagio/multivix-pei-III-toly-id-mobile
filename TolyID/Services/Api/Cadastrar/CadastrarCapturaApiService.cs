using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using TolyID.DTO;
using TolyID.MVVM.Models;


namespace TolyID.Services.Api.Cadastrar
{
    public class CadastrarCapturaApiService : BaseApi
    {
        public struct RespostaCaptura
        {
            public int Id { get; set; }
            public UsuarioDTO Usuario { get; set; }
            public Tatu Tatu { get; set; }
            public DadosGerais DadosGerais { get; set; }
            public FichaAnestesica FichaAnestesica { get; set; }
            public Biometria Biometria { get; set; }
            public Amostras Amostra { get; set; }
        }

        public  async Task Cadastrar(Captura captura, string token)
        {
            try
            {
                CapturaDTO capturaDTO = new(captura);
                var bancotatu = new TatuService();
                Tatu tatu = await bancotatu.GetTatu(captura.TatuId);

                //Debug.WriteLine($"############ => {captura.FichaAnestesica.ParametrosFisiologicos.Count}");

                //foreach (var parametro in captura.FichaAnestesica.ParametrosFisiologicos) 
                //{
                //    Debug.WriteLine($"############ => {parametro.Fc}");
                //    Debug.WriteLine($"############ => {parametro.Fr}");
                //    Debug.WriteLine($"############ => {parametro.Oximetria}");
                //    Debug.WriteLine($"############ => {parametro.Temperatura}");
                //}

                if (tatu.IdAPI == null)
                {
                    Debug.WriteLine("Tatu sem ID API.");
                    return;
                }

                string url = $"http://{UrlBaseApi}:8080/capturas/cadastrar/{tatu.IdAPI}";

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
                        captura.TatuIdAPI = tatu.IdAPI;
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
