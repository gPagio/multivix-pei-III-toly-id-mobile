﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.Constants;
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

            await SecureStorage.GetAsync(AppConstants.SECURE_STORAGE_API_TOKEN_KEY);

            await tatuApiService.CadastraTatu();
            await capturaApiService.CadastraCaptura();
            await tatuApiService.AtualizaTatus();
            await capturaApiService.AtualizaCapturas();

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
