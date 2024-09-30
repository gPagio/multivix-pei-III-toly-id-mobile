using SQLiteNetExtensionsAsync.Extensions;
using TolyID.MVVM.Models;

namespace TolyID.Services;

public class TatuService : BaseDatabaseService
{
    public async Task SalvaTatu(TatuModel tatu)
    {
        await Init();
        await _bancoDeDados.InsertWithChildrenAsync(tatu);
    }

    public async Task<List<TatuModel>> GetTatus()
    {
        await Init();
        var tatus = await _bancoDeDados.GetAllWithChildrenAsync<TatuModel>();
        return tatus.ToList();
    }

    public async Task<TatuModel> GetTatu(int tatuId)
    {
        await Init();
        var tatu = await _bancoDeDados.GetWithChildrenAsync<TatuModel>(tatuId, recursive: true);
        return tatu;
    }

    public async Task AtualizaTatu(TatuModel tatuAtualizado)
    {
        await Init();
        await _bancoDeDados.UpdateWithChildrenAsync(tatuAtualizado);
    }

    public async Task DeletaTatu(TatuModel tatu)
    {
        await Init();
        await _bancoDeDados.DeleteAsync(tatu);
    }
}
