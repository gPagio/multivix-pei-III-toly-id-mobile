using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

    [ObservableProperty]
    private int numeroDeCapturas;

    public TatuViewModel(TatuModel tatu)
    {
        Tatu = tatu;
        //_ = AtualizaTatu(tatu);
    }

    public async Task AtualizaTatu(TatuModel tatu)
    {
        Tatu = await BancoDeDadosService.GetTatuAsync(tatu.Id);
        NumeroDeCapturas = Tatu.Capturas.Count;
    }
}
