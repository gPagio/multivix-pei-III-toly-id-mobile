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

        await _bancoDeDados.CreateTableAsync<Tatu>();
        await _bancoDeDados.CreateTableAsync<Captura>();
        await _bancoDeDados.CreateTableAsync<DadosGerais>();
        await _bancoDeDados.CreateTableAsync<FichaAnestesica>();
        await _bancoDeDados.CreateTableAsync<ParametroFisiologico>();
        await _bancoDeDados.CreateTableAsync<Biometria>();
        await _bancoDeDados.CreateTableAsync<Amostras>();
    } 
}
