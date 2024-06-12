using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class CadastroCapturaTabbedView : TabbedPage
{
    private CadastroCapturaViewModel _viewModel;
	public CadastroCapturaTabbedView(TatuModel tatu)
	{
		InitializeComponent();
        _viewModel = new CadastroCapturaViewModel(tatu);
        BindingContext = _viewModel;
	}

    private void Finalizar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopModalAsync(true);
    }

    private void Voltar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopModalAsync(true);
    }

    private void EntryParametros_TextChanged(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;

        if (e.NewTextValue != string.Empty && e.OldTextValue == 0.ToString() && Convert.ToDouble(entry.Text) % 10 == 0)
        {
            double numeroDigitado = Convert.ToDouble(entry.Text);
            numeroDigitado /= 10;
            entry.Text = numeroDigitado.ToString();
        }
    }

    protected override void OnDisappearing()
    {
        _viewModel.InicializaListasECampos();
    }
}