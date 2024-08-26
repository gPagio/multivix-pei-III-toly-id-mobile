using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CapturaViewModel : ObservableObject
{
    private CapturaModel _captura;
    public CapturaModel Captura
    {
        get => _captura;
        set => SetProperty(ref _captura, value);
    }

    public Dictionary<string, string> DadosGerais { get; } = new();
    public Dictionary<string, string> Biometria { get; } = new();
    public Dictionary<string, string> Amostras { get; } = new();
    public Dictionary<string, string> FichaAnestesica { get; } = new();
    public ObservableCollection<ParametroFisiologicoModel> ParametrosFisiologicos { get; } = new();

    public async void CarregaCaptura(int id)
    {
        Captura = await BancoDeDadosService.GetCapturaAsync(id);

        ParametrosFisiologicos.Clear();

        PreenchePropriedades(Captura.DadosGerais, DadosGerais);
        PreenchePropriedades(Captura.Biometria, Biometria);
        PreenchePropriedades(Captura.Amostras, Amostras);
        PreenchePropriedades(Captura.FichaAnestesica, FichaAnestesica);
        PreencherParametrosFisiologicos();
    }

    // Percorre as propriedades de um dado objeto 'fonte', e armazena o DisplayName e o valor de cada
    // propriedade no dicionário 'alvo'
    private void PreenchePropriedades(object fonte, Dictionary<string, string> alvo)
    {
        if (fonte == null) return;

        var propriedades = fonte.GetType().GetProperties();

        foreach (var prop in propriedades)
        {
            if (prop.Name == "Id") continue;
            if (prop.Name == "ParametrosFisiologicos") continue;

            var displayNameAttribute = prop.GetCustomAttribute<DisplayNameAttribute>();

            // se displayNameAttribute for nulo, displayName será igual ao nome de prop
            var displayName = displayNameAttribute?.DisplayName ?? prop.Name;  

            // Caso não haja valor preenchido em certo campo, não mostrar na tela
            var valor = prop.GetValue(fonte)?.ToString() ?? string.Empty;

            if (valor == string.Empty) continue;
            
            // Verificação feita apenas para propriedades cujos valores são booleanos, ou seja,
            // propriedades de 'AmostrasModel' (exceto 'Outros')
            if (valor == "True") 
            {
                valor = "Coletado";
            } 
            else if(valor == "False")
            {
                valor = "Não Coletado";
            }

            alvo[displayName] = valor;
        }
    }

    private void PreencherParametrosFisiologicos()
    { 
        foreach (var parametro in Captura.FichaAnestesica.ParametrosFisiologicos)
        {
            ParametrosFisiologicos.Add(parametro);
        }
    }
}
