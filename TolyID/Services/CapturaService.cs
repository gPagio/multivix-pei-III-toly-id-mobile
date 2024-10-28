using SQLiteNetExtensionsAsync.Extensions;
using System.Diagnostics;
using TolyID.MVVM.Models;

namespace TolyID.Services;

public class CapturaService : BaseDatabaseService
{
    public async Task SalvaCaptura(Captura novaCaptura, Tatu tatu)
    {
        await Init();
        novaCaptura.TatuId = tatu.Id;
        await _bancoDeDados.InsertWithChildrenAsync(novaCaptura, recursive: true);
    }

    public async Task<Captura> GetCaptura(int capturaId)
    {
        await Init();
        return await _bancoDeDados.GetWithChildrenAsync<Captura>(capturaId, recursive: true);
    }
    public async Task<List<Captura>> GetCapturas()
    {
        await Init();
        return await _bancoDeDados.GetAllWithChildrenAsync<Captura>();

    }

    public async Task AtualizaCaptura(Captura capturaAtualizada)
    {
        await Init();
        await _bancoDeDados.InsertOrReplaceWithChildrenAsync(capturaAtualizada, recursive: true);
    }

    public async Task DeletaCaptura(Captura captura)
    {
        await Init();
        await _bancoDeDados.DeleteAsync(captura, recursive: true);
    }
    public async Task<List<Captura>> GetCapturasNaoCadastradas()
    {
        await Init();

        // Busca todos os Tatus onde Cadastrado é false
        var CapturaNaoCadastrados = await _bancoDeDados.GetAllWithChildrenAsync<Captura>(c => c.FoiEnviadoParaApi == false);

        return CapturaNaoCadastrados;
    }

    public async Task<bool> VerificarExistencia(Captura capturaApi)
    {
        await Init();

        //Debug.WriteLine($"%%%%%%%%%%% NA API => {capturaApi.TatuId}");

        // Busca uma captura que corresponda a todos os campos do objeto recebido.
        // Aviso: talvez o parâmetro TatuId não sirva para comparar efetivamente
        // a existência no banco.
        var existe = await _bancoDeDados.Table<Captura>()
            .Where(c => c.TatuIdAPI == capturaApi.TatuId)
            .FirstOrDefaultAsync();

        return existe != null;
    }
    public async Task DeletarCapturasForaDaApi(List<Captura> listaCapturasApi)
    {
        await Init();
        var capturasLocais = await GetCapturas();

        foreach (var capturaLocal in capturasLocais)
        {
            // Verifica se há correspondência em qualquer captura da lista da API
            bool existeCorrespondencia = listaCapturasApi.Any(capturaApi =>
                capturaApi.TatuId == capturaLocal.TatuId);

            // Se não houver correspondência, deleta a captura
            if (!existeCorrespondencia)
            {
                await DeletaCaptura(capturaLocal);
            }
        }
    }
}
