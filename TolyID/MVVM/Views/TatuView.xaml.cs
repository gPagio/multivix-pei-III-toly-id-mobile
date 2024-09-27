using CommunityToolkit.Maui.Views;
using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class TatuView : ContentPage
{
    private TatuModel _tatu;
    private TatuViewModel _viewModel;

	public TatuView(TatuModel tatu)
	{
		InitializeComponent();
        _viewModel = new TatuViewModel(tatu);
        BindingContext = _viewModel;
        _tatu = tatu;
	}

    private async void AdicionarCaptura_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new CadastroCapturaTabbedView(_tatu)), true);
    }

    private void Microchip_Clicked(object sender, EventArgs e)
    {
        var popup = new MicrochipPopup(_tatu);
        popup.MicrochipAdicionado += Popup_MicrochipAdicionado; // CHAMA O EVENTO
        this.ShowPopup(popup);
    }

    private async void Popup_MicrochipAdicionado(object sender, EventArgs e)
    {
        await _viewModel.AtualizaTatu(_tatu);
    }

    protected async override void OnAppearing()
    {
        await _viewModel.AtualizaTatu(_tatu);
    }
}