#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace TolyID;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();

        bool usuarioEstaLogado = CheckarUsuarioLogado();

        if (!usuarioEstaLogado)
        {
            Shell.Current.GoToAsync("//LoginView");
        }
    }

    private bool CheckarUsuarioLogado()
    {
        // TODO: IMPLEMENTAR LÓGICA
        return false;
    }
}
