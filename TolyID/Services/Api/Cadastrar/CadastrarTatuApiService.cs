using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using TolyID.DTO;
using TolyID.MVVM.Models;


namespace TolyID.Services.Api.Cadastrar;

public class CadastrarTatuApiService : BaseApi
{
    public struct RespostaTatu
    {
        public int Id { get; set; }
        public string IdentificacaoAnimal { get; set; }
        public int? NumeroMicrochip { get; set; }
    }

    private readonly TatuService _tatuService;

    public CadastrarTatuApiService(TatuService tatuService)
    {
        _tatuService = tatuService;
    }

    public async Task Cadastrar(Tatu tatu, string token)
    {
        TatuDTO tatuDTO = new(tatu);

        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Token Inválido");
        } 

        string url = $"http://{UrlBaseApi}:8080/tatus/cadastrar";

        var content = new StringContent(JsonConvert.SerializeObject(tatuDTO), Encoding.UTF8, "application/json");

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                RespostaTatu resposta = JsonConvert.DeserializeObject<RespostaTatu>(jsonResponse);

                tatu.FoiEnviadoParaApi = true;
                tatu.IdAPI = resposta.Id;

                await _tatuService.AtualizaTatu(tatu);
            }
            else
            {
                var mensagemDeErro = await response.Content.ReadAsStringAsync();
                throw new Exception($"{response.StatusCode} - {mensagemDeErro}");
            }
        }
    }
}
