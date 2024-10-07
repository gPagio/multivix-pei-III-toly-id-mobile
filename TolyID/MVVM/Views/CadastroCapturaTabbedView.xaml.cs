using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;
using TolyID.Services;

namespace TolyID.MVVM.Views;

public partial class CadastroCapturaTabbedView : TabbedPage
{
    private CadastroCapturaViewModel _viewModel;

	public CadastroCapturaTabbedView(Tatu tatu, CapturaService capturaService)
	{
		InitializeComponent();
        _viewModel = new CadastroCapturaViewModel(tatu, capturaService);
        BindingContext = _viewModel;
	}

    public CadastroCapturaTabbedView(Tatu tatu, Captura captura, CapturaService capturaService)
    {
        InitializeComponent();
        _viewModel = new CadastroCapturaViewModel(tatu, captura, capturaService);
        BindingContext = _viewModel;
    }

    protected override void OnDisappearing()
    {
        _viewModel.InicializaParametrosFisiologicos();
    }
}