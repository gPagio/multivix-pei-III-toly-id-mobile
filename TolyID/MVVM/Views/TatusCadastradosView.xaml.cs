using CommunityToolkit.Maui.Views;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class TatusCadastradosView : ContentPage
{
    private TatusCadastradosViewModel _viewModel = new();
	public TatusCadastradosView()
	{
		InitializeComponent();
        BindingContext = _viewModel;
	}

    private void AdicionarTatu_Clicked(object sender, EventArgs e)
    {
        var popup = new CadastroTatuPopup();
        popup.TatuAdicionado += Popup_TatuAdicionado;
        this.ShowPopup(popup);
    }

    private async void Popup_TatuAdicionado(object sender, EventArgs e)
    {
        await _viewModel.BuscaTatusNoBanco();
    }

    protected async override void OnAppearing()
    {
        await _viewModel.BuscaTatusNoBanco();
    }
}