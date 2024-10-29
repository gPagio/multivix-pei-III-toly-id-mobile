using TolyID.MVVM.Models;
using TolyID.Services.Api.Cadastrar;
using TolyID.Services.Api.Ler;

namespace TolyID.Services.Api;

public static class CapturaApiService
{
    private static CapturaService _capturaService = new();
    private static CadastrarCapturaApiService _cadastrarCapturaApiService = new();
    private static LerCapturasApiService _lerCapturasApiService = new();
    private static TatuService _tatuService = new();

    public static async Task Cadastrar()
    {
        try
        {
            var token = await TokenApiService.Gerar();
            List<Captura> listaCaptura = await _capturaService.GetCapturasNaoCadastradas();

            foreach (var captura in listaCaptura)
            {
                if (captura.FoiEnviadoParaApi == false)
                {
                    await _cadastrarCapturaApiService.Cadastrar(captura, token);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    public static async Task AtualizarCapturas()
    {
        var token = await TokenApiService.Gerar();
        var capturasApi = await _lerCapturasApiService.Ler(token);

        await DeletarCapturas(capturasApi);

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

    private static async Task DeletarCapturas(List<Captura> capturasRecebidasPelaApi)
    {
        await _capturaService.DeletarCapturasForaDaApi(capturasRecebidasPelaApi); //deve-se enviar a lista de capturas que estão na api
    }
}
