using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CapturaView : ContentPage
{
    //private CapturaModel _captura;
	public CapturaView(CapturaModel captura)
	{
		InitializeComponent();
        //_captura = captura;
        BindingContext = new CapturaViewModel(captura);
	}
}