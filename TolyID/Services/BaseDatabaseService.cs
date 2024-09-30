using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using TolyID.MVVM.Models;

namespace TolyID.Services;

public static class BaseDatabaseService
{
    static SQLiteAsyncConnection _bancoDeDados;

    private static async Task Init()
    {
        if (_bancoDeDados != null) { return; }
       
        var caminhoDoBanco = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tatu.db3");
        _bancoDeDados = new SQLiteAsyncConnection(caminhoDoBanco);

        await _bancoDeDados.CreateTableAsync<TatuModel>();
        await _bancoDeDados.CreateTableAsync<CapturaModel>();
        await _bancoDeDados.CreateTableAsync<DadosGeraisModel>();
        await _bancoDeDados.CreateTableAsync<FichaAnestesicaModel>();
        await _bancoDeDados.CreateTableAsync<ParametroFisiologicoModel>();
        await _bancoDeDados.CreateTableAsync<BiometriaModel>();
        await _bancoDeDados.CreateTableAsync<AmostrasModel>();
    }

    // ========================  CRUD TATUS ======================== 

    public static async Task SalvaTatu(TatuModel tatu)
    {
        await Init();
        await _bancoDeDados.InsertWithChildrenAsync(tatu);
    }

    public static async Task<List<TatuModel>> GetTatus()
    {
        await Init();
        var tatus = await _bancoDeDados.GetAllWithChildrenAsync<TatuModel>();
        return tatus.ToList();
    }

    public static async Task<TatuModel> GetTatu(int tatuId)
    {
        await Init();
        var tatu = await _bancoDeDados.GetWithChildrenAsync<TatuModel>(tatuId, recursive: true);
        return tatu;
    }

    public static async Task AtualizaTatu(TatuModel tatuAtualizado)
    {
        await Init();
        await _bancoDeDados.UpdateWithChildrenAsync(tatuAtualizado);
    }

    public static async Task DeletaTatu(TatuModel tatu)
    {
        await Init();
        await _bancoDeDados.DeleteAsync(tatu);
    }

    // ======================== CRUD CAPTURAS ======================== 
    public static async Task SalvaCaptura(CapturaModel novaCaptura, TatuModel tatu)
    {
        await Init();
        novaCaptura.TatuId = tatu.Id;
        await _bancoDeDados.InsertWithChildrenAsync(novaCaptura, recursive: true);
    }

    public static async Task<CapturaModel> GetCaptura(int capturaId)
    {
        await Init();
        return await _bancoDeDados.GetWithChildrenAsync<CapturaModel>(capturaId, recursive: true);
    }

    public static async Task AtualizaCaptura(CapturaModel capturaAtualizada)
    {
        await Init();
        await _bancoDeDados.InsertOrReplaceWithChildrenAsync(capturaAtualizada, recursive: true);
    }

    public static async Task DeletaCaptura(CapturaModel captura)
    { 
        await Init();
        await _bancoDeDados.DeleteAsync(captura, recursive: true);   
    }
}
