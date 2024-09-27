using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;
using TolyID.Services;

namespace TolyID.MVVM.Views;

public partial class CapturaView : ContentPage
{
    private CapturaModel _captura;
    private CapturaViewModel _viewModel;
	public CapturaView(CapturaModel captura)
	{
		InitializeComponent();
        _captura = captura;
        _viewModel = new CapturaViewModel();
        BindingContext = _viewModel;
	}

    private async void EditarCaptura_Clicked(object sender, EventArgs e)
    {
        var tatu = await BancoDeDadosService.GetTatu(_captura.TatuId);
        await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new CadastroCapturaTabbedView(tatu, _captura)), true);
    }

    protected override void OnAppearing()
    {
        _viewModel.CarregaCaptura(_captura.Id);
    }
}