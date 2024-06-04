using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public class CapturaViewModel : ObservableObject
{
    private CapturaModel _captura;
    public CapturaModel Captura
    {
        get => _captura;
        set => SetProperty(ref _captura, value);
    }

    public CapturaViewModel(CapturaModel captura)
    {
        CarregaCaptura(captura.Id);
        PreencherPropriedades(Captura.DadosGerais, DadosGerais);
        PreencherPropriedades(Captura.Biometria, Biometria);
        PreencherPropriedades(Captura.Amostras, Amostras);
        PreencherPropriedades(Captura.FichaAnestesica, FichaAnestesica);
        PreencherParametrosFisiologicos();
    }

    public Dictionary<string, string> DadosGerais { get; } = new();
    public Dictionary<string, string> Biometria { get; } = new();
    public Dictionary<string, string> Amostras { get; } = new();
    public Dictionary<string, string> FichaAnestesica { get; } = new();
    public ObservableCollection<ParametroFisiologicoModel> ParametrosFisiologicos { get; } = new();

    private async void CarregaCaptura(int id)
    {
        Captura = await BancoDeDadosService.GetCapturaAsync(id);
    }

    private void PreencherPropriedades(object fonte, Dictionary<string, string> alvo)
    {
        if (fonte == null) return;

        var propriedades = fonte.GetType().GetProperties();

        foreach (var prop in propriedades)
        {
            if (prop.Name == "Id") continue;
            if (prop.Name == "ParametrosFisiologicos") continue;

            var displayNameAttribute = prop.GetCustomAttribute<DisplayNameAttribute>();
            var displayName = displayNameAttribute?.DisplayName ?? prop.Name;   // se displayNameAttribute for nulo, displayName será igual ao nome de prop

            var value = prop.GetValue(fonte)?.ToString() ?? string.Empty;
            
            if (value == "True") 
            {
                value = "Coletado";
            } 
            else if(value == "False")
            {
                value = "Não Coletado";
            }

            alvo[displayName] = value;
        }
    }

    private void PreencherParametrosFisiologicos()
    {
        Debug.WriteLine(Captura.FichaAnestesica.ParametrosFisiologicos.Count);
        foreach (var parametro in Captura.FichaAnestesica.ParametrosFisiologicos)
        {
            ParametrosFisiologicos.Add(parametro);
        }
    }
}
