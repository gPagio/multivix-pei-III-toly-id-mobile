using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}