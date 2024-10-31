using TolyID.MVVM.Models;
using TolyID.Services.Api.Cadastrar;
using TolyID.Services.Api.Ler;

namespace TolyID.Services.Api;

public class TatusApiService
{
    private readonly TokenApiService _tokenApiService;
    private readonly CadastrarTatuApiService _cadastrarTatuApiService;
    private readonly LerTatuApiService _lerTatuApiService; 
    private readonly TatuService _tatuService;
    
    public TatusApiService(TokenApiService tokenApiService, CadastrarTatuApiService cadastrarTatuApiService, LerTatuApiService lerTatuApiService ,TatuService tatuService)
    {
        _tokenApiService = tokenApiService;
        _lerTatuApiService = lerTatuApiService;
        _cadastrarTatuApiService = cadastrarTatuApiService;
        _tatuService = tatuService;
    }

    public async Task Cadastrar()
    {
        var token = await SecureStorage.GetAsync("token_api");

        if (string.IsNullOrEmpty(token)) 
        {
            throw new Exception("Token inválido!");
        }

        List<Tatu> listaTatu = await _tatuService.GetTatusNaoCadastrados();
        foreach (var tatu in listaTatu)
        {
            if (!tatu.FoiEnviadoParaApi)
            {
                await _cadastrarTatuApiService.Cadastrar(tatu, token);
            }
        }
    }

    public async Task AtualizarTatus()
    {
        var token = await SecureStorage.GetAsync("token_api");

        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Token inválido!");
        }

        var lista = await _tatuService.GetTatus();
        var listaApi = await _lerTatuApiService.Ler(token);

        await DeletarTatus(listaApi);

        foreach (var tatu in listaApi)
        {
            bool existe = await _tatuService.VerificarExistencia(tatu);

            if (!existe)
            {
                tatu.FoiEnviadoParaApi = true;
                await _tatuService.SalvaTatu(tatu);
            }
        }        
    }

    private async Task DeletarTatus(List<Tatu> tatusRecebidosPelaApi)
    {
        await _tatuService.DeletarTatusForaDaApi(tatusRecebidosPelaApi); //deve-se enviar a lista de Tatus que estao na api
    }
}
