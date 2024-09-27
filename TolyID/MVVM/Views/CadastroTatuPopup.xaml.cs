using CommunityToolkit.Maui.Views;
using TolyID.MVVM.ViewModels;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace TolyID.MVVM.Views;

public partial class CadastroTatuPopup : Popup
{
    public EventHandler TatuAdicionado;
    private readonly CadastroTatuViewModel _viewModel;

	public CadastroTatuPopup()
	{
		InitializeComponent();
        _viewModel = new CadastroTatuViewModel();
        BindingContext = _viewModel;
        IdEntry.Text = "";
    }

    private async void Adicionar_Clicked(object sender, EventArgs e)
    {
        if (IdEntry.Text == "")
        {
            var toast = Toast.Make("Preencha a identificação!", ToastDuration.Short, 14);
            await toast.Show();
            return;
        }

        await _viewModel.AdicionaTatuNoBanco();
        IdEntry.Text = "";

        TatuAdicionado?.Invoke(this, EventArgs.Empty);

        Close();
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}