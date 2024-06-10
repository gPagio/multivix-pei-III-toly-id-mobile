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

    public TatuViewModel(TatuModel tatu)
    {
        Tatu = tatu;
        _ = AtualizaTatu(tatu);
    }

    public async Task AtualizaTatu(TatuModel tatu)
    {
        Tatu = await BancoDeDadosService.GetTatuAsync(tatu.Id);
    }
}
