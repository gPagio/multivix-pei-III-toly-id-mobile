using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Diagnostics;
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

        _bancoDeDados.CreateTable<DadosGeraisModel>();
        _bancoDeDados.CreateTable<BiometriaModel>();
        _bancoDeDados.CreateTable<AmostrasModel>();
        _bancoDeDados.CreateTable<TatuCapturadoModel>();
    }

    //CRUD
    public static async Task SalvaTatuAsync(TatuCapturadoModel tatu)
    {
        await Init();

        DadosGeraisModel dadosGerais = tatu.DadosGerais;
        BiometriaModel biometria = tatu.Biometria;
        AmostrasModel amostras = tatu.Amostras;
        TatuCapturadoModel novoTatu = new();

        _bancoDeDados.Insert(dadosGerais);
        _bancoDeDados.Insert(biometria);
        _bancoDeDados.Insert(amostras);
        _bancoDeDados.Insert(novoTatu);

        novoTatu.DadosGerais = dadosGerais;
        novoTatu.Biometria = biometria;
        novoTatu.Amostras = amostras;

        _bancoDeDados.UpdateWithChildren(novoTatu);

        //_bancoDeDados.InsertWithChildren(tatu);
        //_bancoDeDados.UpdateWithChildren(tatu);
    }

    public static async Task DeletaTatuAsync(int id)
    {
        await Init();
        _bancoDeDados.Delete<TatuCapturadoModel>(id);
    }

    public static async Task<IEnumerable<TatuCapturadoModel>> GetTatusAsync()
    {
        await Init();
        var tatus = _bancoDeDados.Table<TatuCapturadoModel>().ToList();

        foreach (var tatu in tatus)
        {
            _bancoDeDados.GetChildren(tatu);
        }

        return tatus;   
    }
}
