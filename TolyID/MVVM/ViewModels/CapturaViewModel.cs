using CommunityToolkit.Mvvm.ComponentModel;
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

    public async void CarregaCaptura(int id)
    {
        Captura = await _capturaService.GetCaptura(id);
    }
}
