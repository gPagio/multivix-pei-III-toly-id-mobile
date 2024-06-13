using System.Collections.Specialized;
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

        _viewModel.ParametrosFisiologicos.CollectionChanged += ParametrosFisiologicos_CollectionChanged;
	}

    private void Finalizar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopModalAsync(true);
    }

    private void Voltar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopModalAsync(true);
    }

    // Apaga o n�mero 0 dos campos ligados a n�meros ao digitar. Solu��o tempor�ria (apenas para campos 
    // dos par�metros fisiol�gicos da ficha anest�sica)
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

    // Rola para o fim da tela caso novos par�metros fisiol�gicos sejam adicionados
    private async void ParametrosFisiologicos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            await FichaAnestesicaScrollView.ScrollToAsync(0, FichaAnestesicaScrollView.ContentSize.Height, true);
        }
    }

    protected override void OnDisappearing()
    {
        _viewModel.InicializaListasECampos();
    }
}