using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CadastroUsuarioView : ContentPage
{
	public CadastroUsuarioView(CadastroUsuarioViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}