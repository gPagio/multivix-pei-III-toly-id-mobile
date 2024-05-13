using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class Cadastro : ContentPage
{
    CadastroViewModel cadastroViewModel = new();
	public Cadastro()
	{
		InitializeComponent();
        BindingContext = cadastroViewModel;
	}
}