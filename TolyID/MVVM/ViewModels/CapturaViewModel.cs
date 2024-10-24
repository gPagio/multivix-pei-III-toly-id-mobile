using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views.CadastroDeCaptura;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CapturaViewModel : ObservableObject
{
    private readonly CapturaService _capturaService;

    [ObservableProperty]
    private Captura captura;

    [ObservableProperty]
    private TimeSpan horarioDeCaptura;

    public CapturaViewModel(CapturaService capturaService, Captura captura)
    {
        _capturaService = capturaService;
        Captura = captura;
    }

    public async void CarregaCaptura(int id)
    {
        Captura = await _capturaService.GetCaptura(id);
        HorarioDeCaptura = Captura.DadosGerais.DataHoraDeCaptura.TimeOfDay;
    }

    [RelayCommand]
    private async Task EditaCaptura()
    {
        var tatuService = ServiceHelper.GetService<TatuService>();
        var tatu = await tatuService.GetTatu(Captura.TatuId);
        CadastroCapturaViewModel vm = new(tatu, Captura, _capturaService);
        await Shell.Current.Navigation.PushAsync(new DadosGeraisView(vm));
    }

}
