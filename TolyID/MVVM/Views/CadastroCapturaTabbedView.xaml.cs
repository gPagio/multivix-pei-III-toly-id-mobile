using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CadastroCapturaTabbedView : TabbedPage
{
	public CadastroCapturaTabbedView(TatuModel tatu)
	{
		InitializeComponent();
        BindingContext = new CadastroCapturaViewModel(tatu);
	}

    private void Finalizar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopModalAsync(true);
    }
}