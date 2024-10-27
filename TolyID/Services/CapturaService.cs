using SQLiteNetExtensionsAsync.Extensions;
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
    public async Task<List<Captura>> GetCapturaNaoCadastrados()
    {
        await Init();

        // Busca todos os Tatus onde Cadastrado é false
        var CapturaNaoCadastrados = await _bancoDeDados.GetAllWithChildrenAsync<Captura>(c => c.FoiEnviadoParaApi == false);

        return CapturaNaoCadastrados;
    }
}
