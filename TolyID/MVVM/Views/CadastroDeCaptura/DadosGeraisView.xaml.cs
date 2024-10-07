using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views.CadastroDeCaptura;

public partial class DadosGeraisView : ContentPage
{
	public DadosGeraisView(CadastroCapturaViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}