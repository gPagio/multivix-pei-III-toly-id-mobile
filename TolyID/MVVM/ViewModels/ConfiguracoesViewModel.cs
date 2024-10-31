using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.Helpers;
using TolyID.Services.Api;
using TolyID.Services.Api.Gerar;

namespace TolyID.MVVM.ViewModels;

public partial class ConfiguracoesViewModel : ObservableObject
{
    private BaseApi baseApi;

    [ObservableProperty]
    private string ip;

    [ObservableProperty]
    private bool isBusy = false;

    public ConfiguracoesViewModel()
    {
        baseApi = ServiceHelper.GetService<BaseApi>();
        Ip = Preferences.Get("endereco_ip_api", "");
    }

    [RelayCommand]
    private async Task Sincroniza()
    {
        IsBusy = true;
        try
        {
            AtualizaIp();

            var baseApi = ServiceHelper.GetService<BaseApi>();
            baseApi.ReceberRota();

            var gerarToken = ServiceHelper.GetService<GerarTokenApiService>();
            var tatuApiService = ServiceHelper.GetService<TatusApiService>();
            var capturaApiService = ServiceHelper.GetService<CapturaApiService>();

            await SecureStorage.SetAsync("token_api", await gerarToken.Gerar());

            await tatuApiService.Cadastrar();
            await capturaApiService.Cadastrar();
            await tatuApiService.AtualizarTatus();
            await capturaApiService.AtualizarCapturas();

            await Shell.Current.DisplayAlert("Sucesso", "Dados Sincronizados!", "Ok");
        }
        catch (Exception ex) 
        {
            await Shell.Current.DisplayAlert("Erro", $"Ocorreu um erro ao sincronizar os dados: {ex.Message}!", "Ok");
        }
        IsBusy = false;
    }

    private void AtualizaIp()
    {
        Preferences.Set("endereco_ip_api", Ip);
    }
}
