using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class MicrochipPopup : Popup
{
    private MicrochipViewModel _viewModel;
    public event EventHandler MicrochipAdicionado;

    public MicrochipPopup(TatuModel tatu)
	{
		InitializeComponent();
        _viewModel = new MicrochipViewModel(tatu);
        BindingContext = _viewModel;
        ChipEntry.Text = "";
	}

    private async void Adicionar_Clicked(object sender, EventArgs e)
    {
        if (ChipEntry.Text == "")
        {
            var toast = Toast.Make("Preencha o número do microchip!", ToastDuration.Short, 14);
            await toast.Show();
            return;
        }

        await _viewModel.AtualizaMicrochip();

        MicrochipAdicionado?.Invoke(this, EventArgs.Empty);

        Close();
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}