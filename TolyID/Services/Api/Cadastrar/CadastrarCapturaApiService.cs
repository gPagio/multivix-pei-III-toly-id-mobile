using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TolyID.DTO;
using TolyID.MVVM.Models;


namespace TolyID.Services.Api.Cadastrar;

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

    private readonly TatuService _tatuService;
    private readonly CapturaService _capturaService;

    public CadastrarCapturaApiService(TatuService tatuService, CapturaService capturaService)
    {
        _tatuService = tatuService;
        _capturaService = capturaService;
    }

    public async Task Cadastrar(Captura captura, string token)
    {
        CapturaDTO capturaDTO = new(captura);
        Tatu tatu = await _tatuService.GetTatu(captura.TatuId);

        if (tatu.IdAPI == null)
        {
            throw new Exception("Tatu sem ID API.");
        }

        string url = $"http://{UrlBaseApi}:8080/capturas/cadastrar/{tatu.IdAPI}";

        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Token inválido.");
        }

        var content = new StringContent(JsonConvert.SerializeObject(capturaDTO), Encoding.UTF8, "application/json");

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
                await _capturaService.AtualizaCaptura(captura);
            }
            else
            {
                var mensagemDeErro = await response.Content.ReadAsStringAsync();
                throw new Exception($"{response.StatusCode} - {mensagemDeErro}");
            }
        }
    }
}
