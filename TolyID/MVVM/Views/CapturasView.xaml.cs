using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CapturasView : ContentPage
{
    CapturasViewModel viewModel = new();
    
	public CapturasView()
	{
		InitializeComponent();
        BindingContext = viewModel;
        _ = viewModel.CarregaTatus();
    }
}