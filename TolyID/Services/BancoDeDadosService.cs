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

    public static async Task DeletaTatuAsync(int id)
    {
        await Init();
        _bancoDeDados.Delete<TatuModel>(id);
    }

    // ======================== CRUD CAPTURAS ======================== 
    public static async Task SalvaCapturaAsync(CapturaModel novaCaptura, TatuModel tatu)
    {
        await Init();

        try
        {
            FichaAnestesicaModel ficha = novaCaptura.FichaAnestesica;

            // Verificar se a lista de parâmetros fisiológicos não é nula e contém itens
            if (ficha.ParametrosFisiologicos != null && ficha.ParametrosFisiologicos.Count > 0)
            {
                // Inserir a FichaAnestesica antes para garantir que temos um ID para os parâmetros
                _bancoDeDados.Insert(ficha);
                Debug.WriteLine($"FichaAnestesica inserida com ID: {ficha.Id}");

                foreach (var parametro in ficha.ParametrosFisiologicos)
                {
                    parametro.FichaAnestesicaId = ficha.Id;
                    _bancoDeDados.Insert(parametro);

                    // Verificar se o parâmetro foi inserido corretamente
                    var parametroVerificado = _bancoDeDados.Find<ParametroFisiologicoModel>(parametro.Id);
                    if (parametroVerificado == null)
                    {
                        throw new Exception($"Erro ao inserir o parâmetro fisiológico: {parametro.Id}");
                    }
                    else
                    {
                        Debug.WriteLine($"Parâmetro fisiológico inserido: {parametro.Id}");
                    }
                }

                // Carregar a ficha com os parâmetros inseridos
                var fichaVerificada = _bancoDeDados.GetWithChildren<FichaAnestesicaModel>(ficha.Id, true);
                if (fichaVerificada.ParametrosFisiologicos.Count != ficha.ParametrosFisiologicos.Count)
                {
                    throw new Exception("Erro ao inserir os parâmetros fisiológicos na ficha anestésica.");
                }
                else
                {
                    Debug.WriteLine("Todos os parâmetros fisiológicos foram inseridos corretamente.");
                }
            }
            else
            {
                Debug.WriteLine("Nenhum parâmetro fisiológico para inserir.");
            }

            // Inserir a Captura com a ficha e outros modelos associados
            novaCaptura.FichaAnestesicaId = ficha.Id;
            _bancoDeDados.InsertWithChildren(novaCaptura, true);
            Debug.WriteLine($"Captura inserida com ID: {novaCaptura.Id}");

            // Atualizar o Tatu com a nova Captura
            if (tatu.Capturas == null)
            {
                tatu.Capturas = new List<CapturaModel>();
            }
            tatu.Capturas.Add(novaCaptura);
            _bancoDeDados.UpdateWithChildren(tatu);
            Debug.WriteLine($"Tatu atualizado com a nova captura ID: {novaCaptura.Id}");

            // Verificar se a captura foi adicionada corretamente ao Tatu
            var tatuVerificado = _bancoDeDados.GetWithChildren<TatuModel>(tatu.Id, true);
            if (tatuVerificado == null || !tatuVerificado.Capturas.Any(c => c.Id == novaCaptura.Id))
            {
                throw new Exception("Erro ao atualizar o tatu com a nova captura.");
            }
            else
            {
                Debug.WriteLine("Tatu atualizado corretamente com a nova captura.");
            }
        }
        catch (Exception ex)
        {
            // Adicionar log ou mensagem de erro detalhada
            Debug.WriteLine($"Erro ao salvar a captura: {ex.Message}");
            throw;
        }
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
}
