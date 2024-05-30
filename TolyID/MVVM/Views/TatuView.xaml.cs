using TolyID.MVVM.Models;

namespace TolyID.MVVM.Views;

public partial class TatuView : ContentPage
{
	public TatuView(TatuModel tatu)
	{
		InitializeComponent();
        BindingContext = tatu;
	}
}