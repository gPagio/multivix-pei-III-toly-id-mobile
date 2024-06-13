using CommunityToolkit.Mvvm.ComponentModel;
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

    // TODO: este campo servirá para mostrar uma Label indicando que não há capturas
    // feitas para o tatu correspondente. 
    [ObservableProperty]
    private int numeroDeCapturas;   

    public TatuViewModel(TatuModel tatu)
    {
        Tatu = tatu;
    }

    public async Task AtualizaTatu(TatuModel tatu)
    {
        Tatu = await BancoDeDadosService.GetTatuAsync(tatu.Id);
        NumeroDeCapturas = Tatu.Capturas.Count;
    }
}
