using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CadastroCapturaView : ContentPage
{
	public CadastroCapturaView(TatuModel tatu)
	{
		InitializeComponent();
        BindingContext = new CadastroCapturaViewModel(tatu);
    }
}