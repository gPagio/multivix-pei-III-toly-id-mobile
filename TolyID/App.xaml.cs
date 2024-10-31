#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

using TolyID.MVVM.Views.CadastroDeCaptura;

namespace TolyID;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new BiometriaView(new MVVM.ViewModels.CadastroCapturaViewModel(new MVVM.Models.Tatu(), new Services.CapturaService())); 

        bool usuarioEstaLogado = CheckarUsuarioLogado();

        if (!usuarioEstaLogado)
        {
            Shell.Current.GoToAsync("//LoginView");
        }
    }

    private bool CheckarUsuarioLogado()
    {
        // TODO: IMPLEMENTAR LÓGICA
        return true;
    }
}
