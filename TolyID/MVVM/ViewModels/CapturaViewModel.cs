using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views.CadastroDeCaptura;
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

    public async void CarregaCaptura(int id)
    {
        Captura = await _capturaService.GetCaptura(id);
    }

    [RelayCommand]
    private async Task EditaCaptura()
    {
        var tatuService = ServiceHelper.GetService<TatuService>();
        var tatu = await tatuService.GetTatu(_captura.TatuId);
        CadastroCapturaViewModel vm = new(tatu, _captura, _capturaService);
        await Shell.Current.Navigation.PushAsync(new DadosGeraisView(vm));
    }

}
