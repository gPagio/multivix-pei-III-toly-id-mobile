using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class TatuViewModel : ObservableObject
{
    private TatuModel _tatu;
    public TatuModel Tatu
    {
        get => _tatu;
        set => SetProperty(ref _tatu, value);
    }

    public ObservableCollection<CapturaModel> Capturas { get; set; } = new();

    public TatuViewModel(TatuModel tatu)
    {
        Tatu = tatu;
        _ = AtualizaCapturas(tatu);
    }

    public async Task AtualizaCapturas(TatuModel tatu)
    {
        Capturas.Clear();
        var tatuBanco = await BancoDeDadosService.GetTatuAsync(tatu.Id);

        foreach (CapturaModel captura in tatuBanco.Capturas)
        {
            Capturas.Add(captura);
        }
    }
}
