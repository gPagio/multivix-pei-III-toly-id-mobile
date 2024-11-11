using TolyID.MVVM.ViewModels.BottomSheet;

namespace TolyID.MVVM.Views.BottomSheet;

public partial class OrdenarTatusBottomSheet 
{
	public OrdenarTatusBottomSheet(OrdenarTatusViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}