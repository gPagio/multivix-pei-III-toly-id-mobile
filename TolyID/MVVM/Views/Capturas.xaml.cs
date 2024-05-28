using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class Capturas : ContentPage
{
    CapturasViewModel viewModel = new();
    
	public Capturas()
	{
		InitializeComponent();
        BindingContext = viewModel;
        _ = viewModel.CarregaTatus();
    }
}