using TolyID.Constants;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.Services.Api.Cadastrar;
using TolyID.Services.Api.Ler;

namespace TolyID.Services.Api;

public class CapturaApiService
{ 
    private readonly CapturaService _capturaService;
    private readonly CadastrarCapturaApiService _cadastrarCapturaApiService;
    private readonly LerCapturasApiService _lerCapturasApiService;
    private readonly TatuService _tatuService;

    public CapturaApiService(CapturaService capturaService, CadastrarCapturaApiService cadastrarCapturaApiService, LerCapturasApiService lerCapturasApiService, TatuService tatuService)
    {
        _capturaService = capturaService;
        _cadastrarCapturaApiService = cadastrarCapturaApiService;
        _lerCapturasApiService = lerCapturasApiService;
        _tatuService = tatuService;
    }

    public async Task CadastraCaptura()
    {    
        var token = await SecureStorage.GetAsync("token_api");

        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Token inválido!");
        }

        List<Captura> listaCaptura = await _capturaService.GetCapturasNaoCadastradas();

        foreach (var captura in listaCaptura)
        {
            if (captura.FoiEnviadoParaApi == false)
            {
                await _cadastrarCapturaApiService.Cadastrar(captura, token);
            }
        }       
    }

    public async Task AtualizaCapturas()
    {
        var token = await SecureStorage.GetAsync(AppConstants.SECURE_STORAGE_API_TOKEN_KEY);

        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Token inválido!");
        }

        var capturasApi = await _lerCapturasApiService.GetCapturas(token);

        await DeletaCapturas(capturasApi);

        foreach (var capturaApi in capturasApi)
        {
            bool existe = await _capturaService.VerificarExistencia(capturaApi);
            var tatu = await _tatuService.GetTatuPorIdApi(capturaApi.TatuId);

            if (!existe)
            {
                capturaApi.FoiEnviadoParaApi = true;
                await _capturaService.SalvaCaptura(capturaApi, tatu[0]);
            }
        } 
    }

    private async Task DeletaCapturas(List<Captura> capturasRecebidasPelaApi)
    {
        await _capturaService.DeletarCapturasForaDaApi(capturasRecebidasPelaApi); //deve-se enviar a lista de capturas que estão na api 
    }
}
