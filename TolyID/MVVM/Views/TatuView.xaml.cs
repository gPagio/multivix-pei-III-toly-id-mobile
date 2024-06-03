using System.Diagnostics;
using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;
using TolyID.Services;

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
        await Navigation.PushAsync(new CadastroCapturaView(_tatu));
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await _tatuViewModel.AtualizaCapturas(_tatu);
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
        await _tatuViewModel.AtualizaCapturas(_tatu);
    }
}