using System.IdentityModel.Tokens.Jwt;
using TolyID.Constants;
using TolyID.MVVM.Views;

namespace TolyID;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        RegisterForRoute<ConfiguracoesView>();
    }

    protected void RegisterForRoute<T>()
    {
        Routing.RegisterRoute(typeof(T).Name, typeof(T));
    }
}
