using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CapturaViewModel : ObservableObject
{
    private readonly CapturaService _capturaService;

    private Captura _captura;
    public Captura Captura
    {
        get => _captura;
        set => SetProperty(ref _captura, value);
    }

    public CapturaViewModel(CapturaService capturaService)
    {
        _capturaService = capturaService;
    }

    public ObservableCollection<KeyValuePair<string, string>> DadosGerais { get; } = new();
    public ObservableCollection<KeyValuePair<string, string>> Biometria { get; } = new();
    public ObservableCollection<KeyValuePair<string, string>> Amostras { get; } = new();
    public ObservableCollection<KeyValuePair<string, string>> FichaAnestesica { get; } = new();
    public ObservableCollection<ParametroFisiologico> ParametrosFisiologicos { get; } = new();

    public async void CarregaCaptura(int id)
    {
        Captura = await _capturaService.GetCaptura(id);

        ParametrosFisiologicos.Clear();

        PreenchePropriedades(Captura.DadosGerais, DadosGerais);
        PreenchePropriedades(Captura.Biometria, Biometria);
        PreenchePropriedades(Captura.Amostras, Amostras);
        PreenchePropriedades(Captura.FichaAnestesica, FichaAnestesica);
        PreencheParametrosFisiologicos();
    }

    // Percorre as propriedades de um dado objeto 'fonte', e armazena o DisplayName e o valor de cada
    // propriedade na ObservableCollection 'alvo'
    private void PreenchePropriedades(object fonte, ObservableCollection<KeyValuePair<string, string>> alvo)
    {
        if (fonte == null) return;

        alvo.Clear(); // Limpa antes de preencher com novos valores

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

            // Solução temporária para não mostrar o horário de DateTime
            // TODO: mudar a forma como a informação é armazenada no banco
            if (prop.Name == "DataDeCaptura")
            {
                if (DateTime.TryParse(prop.GetValue(fonte)?.ToString(), out DateTime dataCaptura))
                {
                    valor = dataCaptura.ToString("dd/MM/yyyy");
                }
            }

            if (valor == string.Empty) continue;

            // Verificação feita apenas para propriedades cujos valores são booleanos, ou seja,
            // propriedades de 'AmostrasModel' (exceto 'Outros')
            if (valor == "True")
            {
                valor = "Coletado";
            }
            else if (valor == "False")
            {
                valor = "Não Coletado";
            }

            alvo.Add(new KeyValuePair<string, string>(displayName, valor));
        }
    }

    private void PreencheParametrosFisiologicos()
    {
        foreach (var parametro in Captura.FichaAnestesica.ParametrosFisiologicos)
        {
            ParametrosFisiologicos.Add(parametro);
        }
    }
}
