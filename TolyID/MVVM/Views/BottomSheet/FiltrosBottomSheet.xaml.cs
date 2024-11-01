using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views.BottomSheet;

public partial class FiltrosBottomSheet
{
    private readonly TatusCadastradosViewModel _vm;
	public FiltrosBottomSheet(TatusCadastradosViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
	}
}