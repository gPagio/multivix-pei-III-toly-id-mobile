using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TolyID.MVVM.Models;

namespace TolyID.Services;

public static class BancoDeDadosService
{
    static SQLiteConnection _bancoDeDados;

    static async Task Init()
    {
        if (_bancoDeDados != null) { return; }
       
        var caminhoDoBanco = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tatu.db3");
        _bancoDeDados = new SQLiteConnection(caminhoDoBanco);

        _bancoDeDados.CreateTable<TatuModel>();
        _bancoDeDados.CreateTable<CapturaModel>();
        _bancoDeDados.CreateTable<DadosGeraisModel>();
        _bancoDeDados.CreateTable<BiometriaModel>();
        _bancoDeDados.CreateTable<AmostrasModel>();
    }

    // ========================  CRUD TATUS ======================== 

    public static async Task SalvaTatuAsync(TatuModel tatu)
    {
        await Init();
        _bancoDeDados.Insert(tatu);
    }

    public static async Task<IEnumerable<TatuModel>> GetTatusAsync()
    {
        await Init();
        var tatus = _bancoDeDados.GetAllWithChildren<TatuModel>().ToList();

        return tatus;
    }

    public static async Task DeletaTatuAsync(int id)
    {
        await Init();
        _bancoDeDados.Delete<CapturaModel>(id);
    }

    // ======================== CRUD CAPTURAS ======================== 
    public static async Task SalvaCapturaAsync(CapturaModel captura)
    {
        await Init();

    }

    public static async Task<IEnumerable<CapturaModel>> GetCapturasAsync(TatuModel tatu)
    {
        await Init();
        var capturas = _bancoDeDados.GetAllWithChildren<CapturaModel>().ToList();

        return capturas;
    }
}
