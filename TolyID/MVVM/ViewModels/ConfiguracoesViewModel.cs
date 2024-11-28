using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.Constants;
using TolyID.Helpers;
using TolyID.Services.Api;
using TolyID.Services.Api.Gerar;
using Microsoft.Maui.Networking;
using Microsoft.Maui.Storage;

namespace TolyID.MVVM.ViewModels;

public partial class ConfiguracoesViewModel : ObservableObject
{
    private BaseApi baseApi;

    [ObservableProperty]
    private string ip;

    [ObservableProperty]
    private bool estaCarregando = false;

    public ConfiguracoesViewModel()
    {
        baseApi = ServiceHelper.GetService<BaseApi>();
        Ip = Preferences.Get("endereco_ip_api", "");
    }

    [RelayCommand]
    private async Task Sincroniza()
    {
        EstaCarregando = true;
        try
        {
            AtualizaIp();

            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType != NetworkAccess.Internet)
            {
                throw new Exception("Não há conexão com internet disponível. Tente novamente mais tarde.");
            }

            var baseApi = ServiceHelper.GetService<BaseApi>();
            baseApi.ReceberRota();

            var gerarToken = ServiceHelper.GetService<GerarTokenApiService>();
            var tatuApiService = ServiceHelper.GetService<TatusApiService>();
            var capturaApiService = ServiceHelper.GetService<CapturaApiService>();

            var token = await SecureStorage.GetAsync(AppConstants.SECURE_STORAGE_API_TOKEN_KEY);

            // Confere se usuário está logado ou não
            if (string.IsNullOrEmpty(token))
            {
                EstaCarregando = false;
                bool resposta = await Shell.Current.DisplayAlert("Erro", "Você está offline. Realize login para sincronizar os dados", "Fazer Login", "Cancelar");

                if (resposta) 
                {
                    await Shell.Current.GoToAsync("//LoginView");
                }

                return;
            }

            await tatuApiService.CadastraTatu();
            await capturaApiService.CadastraCaptura();
            await tatuApiService.AtualizaTatus();
            await capturaApiService.AtualizaCapturas();

            await Shell.Current.DisplayAlert("Sucesso", "Dados Sincronizados!", "Ok");
        }
        catch (Exception ex) 
        {
            await Shell.Current.DisplayAlert("Erro", $"{ex.Message}", "Ok");
        }
        EstaCarregando = false;
    }

    private void AtualizaIp()
    {
        Preferences.Set("endereco_ip_api", Ip);
    }

    [RelayCommand]
    private async Task Deslogar()
    {
        bool resposta = await Shell.Current.DisplayAlert
            ("Confirmação",
            $"Você tem certeza que deseja sair?",
            "Sim",
            "Não");

        if (resposta)
        {
            await SecureStorage.SetAsync(AppConstants.SECURE_STORAGE_API_TOKEN_KEY, "");
            await Shell.Current.GoToAsync("//LoginView");
        }
    }
}
