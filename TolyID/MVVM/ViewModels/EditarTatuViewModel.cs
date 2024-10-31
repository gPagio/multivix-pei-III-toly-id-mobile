using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class EditarTatuViewModel : ObservableObject
{ 
    private readonly TatuService _tatuService;

    [ObservableProperty]
    private bool microchipAtivado = false;

    [ObservableProperty]
    private int numeroMicrochip;

    private Tatu _tatu;
    public Tatu Tatu
    {
        get => _tatu;
        set => SetProperty(ref _tatu, value);
    }

    public EditarTatuViewModel(Tatu tatu, TatuService tatuService)
    {
        Tatu = tatu;
        NumeroMicrochip = tatu.NumeroMicrochip;
        _tatuService = tatuService;
    }

    private async Task AtualizaMicrochip()
    {
        Tatu.NumeroMicrochip = NumeroMicrochip;
       await _tatuService.AtualizaTatu(Tatu);
    }

    [RelayCommand]
    private async Task Atualiza()
    {
        await AtualizaMicrochip();
    }
}
