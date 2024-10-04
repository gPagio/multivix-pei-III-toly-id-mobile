using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class EditarTatuPopup : Popup
{
    public EditarTatuPopup(EditarTatuViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        ChipEntry.Text = "";
	}

    private async void Atualizar_Clicked(object sender, EventArgs e)
    {
        if (ChipEntry.Text == "" && MicrochipSwitch.IsToggled)
        {
            var toast = Toast.Make("Preencha o número do microchip!", ToastDuration.Short, 14);
            await toast.Show();
            return;
        }

        Close();
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}