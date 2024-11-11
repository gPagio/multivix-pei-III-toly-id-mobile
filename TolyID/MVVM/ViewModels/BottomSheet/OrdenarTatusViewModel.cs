using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SQLite;
using System.Diagnostics;
using TolyID.Messages;

namespace TolyID.MVVM.ViewModels.BottomSheet;

public partial class OrdenarTatusViewModel : ObservableObject
{
    [ObservableProperty]
    private int ordem;

    [ObservableProperty]
    private int parametro;


    [RelayCommand]
    private async Task Ordena()
    {
        Dictionary<int, int> ordemEParametro = new()
        {
            {Ordem, Parametro}
        };

        WeakReferenceMessenger.Default.Send(new OrdenarTatusMessage(ordemEParametro));
        await FechaBottomSheet();
    }

    private async Task FechaBottomSheet()
    {
        await Shell.Current.GoToAsync("..");
    }
}
