using CommunityToolkit.Maui.Views;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CadastroTatuPopup : Popup
{
	public CadastroTatuPopup(CadastroTatuViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        IdEntry.Text = "";
    }

    private void Adicionar_Clicked(object sender, EventArgs e)
    {
        if (IdEntry.Text == "")
        {
            return;
        }

        Close();
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}