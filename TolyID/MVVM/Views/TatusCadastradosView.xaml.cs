using CommunityToolkit.Maui.Views;
using Java.Lang;
using System.Diagnostics;
using TolyID.MVVM.Models;
using TolyID.MVVM.ViewModels;

namespace TolyID.MVVM.Views;

public partial class TatusCadastradosView : ContentPage
{
    TatusCadastradosViewModel viewModel = new();
	public TatusCadastradosView()
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    private void AdicionarTatu_Clicked(object sender, EventArgs e)
    {
        this.ShowPopup(new CadastroTatuPopup());
    }

    private async void Tatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var tatuSelecionado = e.CurrentSelection[0] as TatuModel;

            if(tatuSelecionado != null)
            {
                Debug.WriteLine($"{tatuSelecionado.IdentificacaoAnimal}");
                await Navigation.PushAsync(new TatuView(tatuSelecionado));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }

    protected override void OnAppearing()
    {
        viewModel.BuscaTatusNoBanco();
    }
}