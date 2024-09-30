using SQLiteNetExtensionsAsync.Extensions;
using TolyID.MVVM.Models;

namespace TolyID.Services;

public class CapturaService : BaseDatabaseService
{
    public async Task SalvaCaptura(CapturaModel novaCaptura, TatuModel tatu)
    {
        await Init();
        novaCaptura.TatuId = tatu.Id;
        await _bancoDeDados.InsertWithChildrenAsync(novaCaptura, recursive: true);
    }

    public async Task<CapturaModel> GetCaptura(int capturaId)
    {
        await Init();
        return await _bancoDeDados.GetWithChildrenAsync<CapturaModel>(capturaId, recursive: true);
    }

    public async Task AtualizaCaptura(CapturaModel capturaAtualizada)
    {
        await Init();
        await _bancoDeDados.InsertOrReplaceWithChildrenAsync(capturaAtualizada, recursive: true);
    }

    public async Task DeletaCaptura(CapturaModel captura)
    {
        await Init();
        await _bancoDeDados.DeleteAsync(captura, recursive: true);
    }
}
