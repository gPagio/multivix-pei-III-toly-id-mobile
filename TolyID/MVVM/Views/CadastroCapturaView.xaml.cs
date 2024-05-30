using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CadastroCapturaView : ContentPage
{
	public CadastroCapturaView()
	{
		InitializeComponent();
        BindingContext = new CadastroViewModel();
    }

    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //    CadastroViewModel.Teste();
    //}
}