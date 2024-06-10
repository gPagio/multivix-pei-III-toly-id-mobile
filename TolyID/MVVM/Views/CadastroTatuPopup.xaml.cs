using CommunityToolkit.Maui.Views;
using TolyID.MVVM.ViewModels;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace TolyID.MVVM.Views;

public partial class CadastroTatuPopup : Popup
{
    public EventHandler TatuAdicionado;

	public CadastroTatuPopup()
	{
		InitializeComponent();
        BindingContext = new CadastroTatuViewModel();
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

        _ = CadastroTatuViewModel.AdicionaTatuNoBanco();
        IdEntry.Text = "";

        TatuAdicionado?.Invoke(this, EventArgs.Empty);

        Close();
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void MicrochipEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;

        if (e.NewTextValue != string.Empty && e.OldTextValue == 0.ToString() && Convert.ToDouble(entry.Text) % 10 == 0)
        {
            double numeroDigitado = Convert.ToDouble(entry.Text);
            numeroDigitado /= 10;
            entry.Text = numeroDigitado.ToString();
        }
    }
}