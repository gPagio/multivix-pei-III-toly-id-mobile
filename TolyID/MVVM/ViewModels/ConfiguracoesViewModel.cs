using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using TolyID.Helpers;
using TolyID.Services.Api;

namespace TolyID.MVVM.ViewModels;

public partial class ConfiguracoesViewModel : ObservableObject
{
    private BaseApi baseApi;

    [ObservableProperty]
    private string ip;

    public ConfiguracoesViewModel()
    {
        baseApi = ServiceHelper.GetService<BaseApi>();
        Ip = baseApi.UrlBaseApi;
    }

    [RelayCommand]
    private void AtualizaIp()
    {
        Preferences.Default.Set("endereco_ip_api", Ip);
        Shell.Current.DisplayAlert("Sucesso", "Ip configurado!", "Ok");
    }
}
