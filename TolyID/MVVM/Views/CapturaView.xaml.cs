using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;
using TolyID.Services;

namespace TolyID.MVVM.Views;

public partial class CapturaView : ContentPage
{
    private readonly CapturaModel _captura;
    private readonly CapturaViewModel _viewModel;
    private readonly TatuService _tatuService;

	public CapturaView(CapturaModel captura, CapturaViewModel viewModel, TatuService tatuService)
	{
		InitializeComponent();
        _captura = captura;
        _viewModel = viewModel;
        _tatuService = tatuService;
        BindingContext = viewModel;
	}

    private async void EditarCaptura_Clicked(object sender, EventArgs e)
    {
        var tatu = await _tatuService.GetTatu(_captura.TatuId);
        var capturaService = ServiceHelper.GetService<CapturaService>();
        await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new CadastroCapturaTabbedView(tatu, _captura, capturaService)), true);
    }

    protected override void OnAppearing()
    {
        _viewModel.CarregaCaptura(_captura.Id);
    }
}