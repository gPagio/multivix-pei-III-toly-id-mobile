using System.Diagnostics;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;
using TolyID.Services;

namespace TolyID.MVVM.Views;

public partial class CapturaView : ContentPage
{
    private readonly Captura _captura;
    private readonly CapturaViewModel _viewModel;

	public CapturaView(Captura captura, CapturaViewModel viewModel)
	{
		InitializeComponent();
        _captura = captura;
        _viewModel = viewModel;
        BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        _viewModel.CarregaCaptura(_captura.Id);
    }
}