using CommunityToolkit.Maui.Views;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CadastroTatuPopup : Popup
{
	public CadastroTatuPopup()
	{
		InitializeComponent();
        BindingContext = new CadastroTatuViewModel();
	}

    private void Adicionar_Clicked(object sender, EventArgs e)
    {
        _ = CadastroTatuViewModel.AdicionaTatuNoBanco();
        IdEntry.Text = "";
        //MicrochipEntry.Text = 0.ToString();
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