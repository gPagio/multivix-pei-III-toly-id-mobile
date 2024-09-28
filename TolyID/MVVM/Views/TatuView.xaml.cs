using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class TatuView : ContentPage
{
    private readonly TatuModel _tatu;
    private readonly TatuViewModel _viewModel;

    public TatuView(TatuViewModel viewModel, TatuModel tatu)
	{
		InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
        _tatu = tatu;
	}

    protected async override void OnAppearing()
    {
        await _viewModel.AtualizaTatu(_tatu);
    }
}