using CommunityToolkit.Mvvm.ComponentModel;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public class MicrochipViewModel : ObservableObject
{
    private TatuModel _tatu;
    public TatuModel Tatu
    {
        get => _tatu;
        set => SetProperty(ref _tatu, value);
    }

    public MicrochipViewModel(TatuModel tatu)
    {
        _tatu = tatu;
    }

    public async Task AtualizaMicrochip()
    {
       await BancoDeDadosService.AtualizaTatuAsync(_tatu);
    }
}
