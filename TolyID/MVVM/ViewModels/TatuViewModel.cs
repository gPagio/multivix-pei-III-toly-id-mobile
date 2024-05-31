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
        AtualizaCapturas(tatu);
    }

    private void AtualizaCapturas(TatuModel tatu)
    {
        Capturas = new ObservableCollection<CapturaModel>(tatu.Capturas);
    }
}
