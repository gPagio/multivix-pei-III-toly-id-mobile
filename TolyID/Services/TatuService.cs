using SQLiteNetExtensionsAsync.Extensions;
using TolyID.MVVM.Models;

namespace TolyID.Services;

public class TatuService : BaseDatabaseService
{
    public async Task SalvaTatu(Tatu tatu)
    {
        await Init();
        await _bancoDeDados.InsertWithChildrenAsync(tatu);
    }

    public async Task<List<Tatu>> GetTatus()
    {
        await Init();
        var tatus = await _bancoDeDados.GetAllWithChildrenAsync<Tatu>();
        return tatus.ToList();
    }

    public async Task<Tatu> GetTatu(int tatuId)
    {
        await Init();
        var tatu = await _bancoDeDados.GetWithChildrenAsync<Tatu>(tatuId, recursive: true);
        return tatu;
    }

    public async Task AtualizaTatu(Tatu tatuAtualizado)
    {
        await Init();
        await _bancoDeDados.UpdateWithChildrenAsync(tatuAtualizado);
    }

    public async Task DeletaTatu(Tatu tatu)
    {
        await Init();
        await _bancoDeDados.DeleteAsync(tatu);
    }
    public async Task<List<Tatu>> GetTatusNaoCadastrados()
    {
        await Init();

        // Busca todos os Tatus onde Cadastrado é false
        var tatusNaoCadastrados = await _bancoDeDados.Table<Tatu>()
            .Where(t => t.FoiEnviadoParaApi == false)
            .ToListAsync();

        return tatusNaoCadastrados;
    }
}
