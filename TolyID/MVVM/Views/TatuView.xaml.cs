using CommunityToolkit.Maui.Views;
using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class TatuView : ContentPage
{
    private TatuModel _tatu;
    private TatuViewModel _tatuViewModel;

	public TatuView(TatuModel tatu)
	{
		InitializeComponent();
        _tatuViewModel = new TatuViewModel(tatu);
        BindingContext = _tatuViewModel;
        _tatu = tatu;
	}

    private async void AdicionarCaptura_Clicked(object sender, EventArgs e)
    {
        //await Shell.Current.Navigation.PushModalAsync(new CadastroCapturaTabbedView(_tatu), true);
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
        await _tatuViewModel.AtualizaTatu(_tatu);
    }

    private async void Capturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var capturaSelecionada = e.CurrentSelection[0] as CapturaModel;

            if (capturaSelecionada != null)
            {
                await Navigation.PushAsync(new CapturaView(capturaSelecionada));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }

    protected async override void OnAppearing()
    {
        await _tatuViewModel.AtualizaTatu(_tatu);
    }
}