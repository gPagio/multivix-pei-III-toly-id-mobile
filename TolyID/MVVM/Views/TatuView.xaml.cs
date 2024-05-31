using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class TatuView : ContentPage
{
	public TatuView(TatuModel tatu)
	{
		InitializeComponent();
        BindingContext = new TatuViewModel(tatu);
	}

    private async void AdicionarCaptura_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroCapturaView());
    }
}