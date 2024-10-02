using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views.CadastroDeCaptura;

public partial class FichaAnestesicaView : ContentPage
{
	public FichaAnestesicaView()
	{
		InitializeComponent();
    }

    private void AdicionarParametro_Clicked(object sender, EventArgs e)
    {
        FichaAnestesicaScrollView.ScrollToAsync(0, FichaAnestesicaScrollView.ContentSize.Height, true);
    }
}