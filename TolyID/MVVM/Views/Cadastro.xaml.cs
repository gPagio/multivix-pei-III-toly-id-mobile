using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();
        BindingContext = new CadastroViewModel();
    }
}