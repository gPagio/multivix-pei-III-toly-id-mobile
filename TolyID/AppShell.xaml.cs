using TolyID.MVVM.Views;

namespace TolyID
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterForRoute<ConfiguracoesView>();

            Preferences.Default.Set("endereco_ip_api", "");
        }

        protected void RegisterForRoute<T>()
        {
            Routing.RegisterRoute(typeof(T).Name, typeof(T));
        }
    }
}
