using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class MicrochipViewModel : ObservableObject
{
    private TatuModel _tatu;
    public TatuModel Tatu
    {
        get => _tatu;
        set => SetProperty(ref _tatu, value);
    }

    public MicrochipViewModel(TatuModel tatu)
    {
        Tatu = tatu;
    }

    private async Task AtualizaMicrochip()
    {
       await BaseDatabaseService.AtualizaTatu(Tatu);
    }

    [RelayCommand]
    private async Task Atualiza()
    {
        await AtualizaMicrochip();
    }
}
