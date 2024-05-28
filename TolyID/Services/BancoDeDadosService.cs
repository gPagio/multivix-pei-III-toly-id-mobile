using SQLite;
using TolyID.MVVM.Models;

namespace TolyID.Services;

public static class BancoDeDadosService
{
    static SQLiteAsyncConnection _bancoDeDados;

    static async Task Init()
    {
        if (_bancoDeDados != null) { return; }

        var caminhoDoBanco = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tatu.db3");
        _bancoDeDados = new SQLiteAsyncConnection(caminhoDoBanco);

        await _bancoDeDados.CreateTableAsync<DadosGeraisModel>();
        await _bancoDeDados.CreateTableAsync<BiometriaModel>();
        await _bancoDeDados.CreateTableAsync<AmostrasModel>();
        await _bancoDeDados.CreateTableAsync<TatuCapturadoModel>();
    }

    //CRUD
    public static async Task SalvaTatuAsync(TatuCapturadoModel tatu)
    {
        await Init();

        await _bancoDeDados.InsertAsync(tatu);

        //await _bancoDeDados.InsertAsync(tatu.DadosGerais);
        //await _bancoDeDados.InsertAsync(tatu.Biometria);
        //await _bancoDeDados.InsertAsync(tatu.Amostras);
        //await _bancoDeDados.UpdateAsync(tatu.DadosGerais);
        //await _bancoDeDados.UpdateAsync(tatu.Biometria);
        //await _bancoDeDados.UpdateAsync(tatu.Amostras);
        //await _bancoDeDados.UpdateAsync(tatu);
    }

    public static async Task DeletaTatuAsync(int id)
    {
        await Init();
        await _bancoDeDados.DeleteAsync<TatuCapturadoModel>(id);
    }

    public static async Task<IEnumerable<TatuCapturadoModel>> GetTatusAsync()
    {
        await Init();
        var tatus = await _bancoDeDados.Table<TatuCapturadoModel>().ToListAsync();
        return tatus;
    }

}
