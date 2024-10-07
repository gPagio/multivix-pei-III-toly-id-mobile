using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views.CadastroDeCaptura;

public partial class AmostrasView : ContentPage
{
	public AmostrasView(CadastroCapturaViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}