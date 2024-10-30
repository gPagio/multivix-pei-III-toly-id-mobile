using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class ConfiguracoesView : ContentPage
{
	public ConfiguracoesView(ConfiguracoesViewModel configuracoesViewModel)
	{
		InitializeComponent();
        BindingContext = configuracoesViewModel;
	}
}