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

        _bancoDeDados.CreateTable<TatuModel>();
        _bancoDeDados.CreateTable<CapturaModel>();
        _bancoDeDados.CreateTable<DadosGeraisModel>();
        _bancoDeDados.CreateTable<FichaAnestesicaModel>();
        _bancoDeDados.CreateTable<ParametroFisiologicoModel>();
        _bancoDeDados.CreateTable<BiometriaModel>();
        _bancoDeDados.CreateTable<AmostrasModel>();
    }

    // ========================  CRUD TATUS ======================== 

    public static async Task SalvaTatuAsync(TatuModel tatu)
    {
        await Init();
        _bancoDeDados.InsertWithChildren(tatu);
    }

    public static async Task<IEnumerable<TatuModel>> GetTatusAsync()
    {
        await Init();
        var tatus = _bancoDeDados.GetAllWithChildren<TatuModel>().ToList();
        return tatus;
    }

    public static async Task<TatuModel> GetTatuAsync(int tatuId)
    {
        await Init();
        var tatu = _bancoDeDados.GetWithChildren<TatuModel>(tatuId);

        foreach (var captura in tatu.Capturas)
        {
            _bancoDeDados.GetChildren(captura);
            _bancoDeDados.GetChildren(captura.DadosGerais);
            _bancoDeDados.GetChildren(captura.Biometria);
            _bancoDeDados.GetChildren(captura.Amostras);
            _bancoDeDados.GetChildren(captura.FichaAnestesica);
        }

        return tatu;
    }

    public static async Task AtualizaTatuAsync(TatuModel tatuAtualizado)
    {
        await Init();
        var tatu = await GetTatuAsync(tatuAtualizado.Id);
        
        if (tatu != null)
        {
            tatu.IdentificacaoAnimal = tatuAtualizado.IdentificacaoAnimal;
            tatu.NumeroMicrochip = tatuAtualizado.NumeroMicrochip;
            tatu.Capturas = tatuAtualizado.Capturas;
        }

        _bancoDeDados.UpdateWithChildren(tatu);
    }

    public static async Task DeletaTatuAsync(TatuModel tatu)
    {
        await Init();
        var tatuSelecionado = _bancoDeDados.GetWithChildren<TatuModel>(tatu.Id);

        foreach (var captura in tatuSelecionado.Capturas) 
        { 
            await DeletaCapturaAsync(captura);  
        }

        _bancoDeDados.Delete<TatuModel>(tatu.Id);
    }

    // ======================== CRUD CAPTURAS ======================== 
    public static async Task SalvaCapturaAsync(CapturaModel novaCaptura, TatuModel tatu)
    {
        await Init();

        FichaAnestesicaModel ficha = novaCaptura.FichaAnestesica;

        // Verificar se a lista de parâmetros fisiológicos não é nula e contém itens
        if (ficha.ParametrosFisiologicos != null && ficha.ParametrosFisiologicos.Count > 0)
        {
            // Inserir a FichaAnestesica antes para garantir que temos um ID para os parâmetros
            _bancoDeDados.Insert(ficha);

            foreach (var parametro in ficha.ParametrosFisiologicos)
            {
                parametro.FichaAnestesicaId = ficha.Id;
                _bancoDeDados.Insert(parametro);
            }
        }

        // Inserir a Captura com a ficha e outros modelos associados
        novaCaptura.FichaAnestesicaId = ficha.Id;
        _bancoDeDados.InsertWithChildren(novaCaptura, true);

        // Atualizar o Tatu com a nova Captura
        if (tatu.Capturas == null)
        {
            tatu.Capturas = new List<CapturaModel>();
        }
        tatu.Capturas.Add(novaCaptura);
        _bancoDeDados.UpdateWithChildren(tatu);
    }

    public static async Task<CapturaModel> GetCapturaAsync(int capturaId)
    {
        await Init();
        var captura = _bancoDeDados.GetWithChildren<CapturaModel>(capturaId);

        _bancoDeDados.GetChildren(captura.DadosGerais);
        _bancoDeDados.GetChildren(captura.Biometria);
        _bancoDeDados.GetChildren(captura.FichaAnestesica);
        _bancoDeDados.GetChildren(captura.Amostras);

        return captura;
    }

    public static async Task DeletaCapturaAsync(CapturaModel captura)
    { 
        await Init();

        _bancoDeDados.Delete<DadosGeraisModel>(captura.DadosGeraisId);
        _bancoDeDados.Delete<BiometriaModel>(captura.BiometriaId);
        _bancoDeDados.Delete<AmostrasModel>(captura.AmostrasId);

        foreach (var parametroFisiologico in captura.FichaAnestesica.ParametrosFisiologicos)
        {
            _bancoDeDados.Delete<ParametroFisiologicoModel>(parametroFisiologico.Id);
        }

        _bancoDeDados.Delete<FichaAnestesicaModel>(captura.FichaAnestesicaId);
        _bancoDeDados.Delete<CapturaModel>(captura.Id);   
    }
}
