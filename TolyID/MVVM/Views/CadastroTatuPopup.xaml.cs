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
        MicrochipEntry.Text = 0.ToString();
    }


    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}