using SQLite;
using TolyID.MVVM.Models;

namespace TolyID.Services;

public class BaseDatabaseService
{
    protected static SQLiteAsyncConnection _bancoDeDados;

    public BaseDatabaseService()
    {

    }

    protected async Task Init()
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
}
