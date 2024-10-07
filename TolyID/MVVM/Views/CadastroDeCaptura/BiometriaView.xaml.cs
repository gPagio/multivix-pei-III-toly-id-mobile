using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views.CadastroDeCaptura;

public partial class BiometriaView : ContentPage
{
	public BiometriaView(CadastroCapturaViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}