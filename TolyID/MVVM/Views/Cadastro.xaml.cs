using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class Cadastro : ContentPage
{
    CadastroViewModel viewModel = new();

	public Cadastro()
	{
		InitializeComponent();
        //BindingContext = new CadastroViewModel();
        BindingContext = viewModel;
    }

}