using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class TatusCadastradosView : ContentPage
{
    private readonly TatusCadastradosViewModel _viewModel;
    public TatusCadastradosView(TatusCadastradosViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        _viewModel.BuscaTatusNoBanco();
    }
}