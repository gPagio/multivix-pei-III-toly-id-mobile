using CommunityToolkit.Mvvm.ComponentModel;

namespace TolyID.MVVM.Models;

public class CampoCadastroModel : ObservableObject
{    
    private string _nome;
    private object _valor;
    private View _entradaDeDado;    // Define qual View usar para capturar dados digitados pelo usuário (Entry, DatePicker etc.)

    public string Nome
    {
        get => _nome; 
        set => SetProperty(ref _nome, value); // SetProperty notifica a interface
    }

    public object Valor
    {
        get => _valor;
        set => SetProperty(ref _valor, value);
    }

    public View EntradaDeDado
    {
        get => _entradaDeDado;
        set => SetProperty(ref _entradaDeDado, value);         
    }

    public CampoCadastroModel(string nome, View entradaDeDado)
    {
        Nome = nome;
        EntradaDeDado = entradaDeDado;
        //ConfigurarBinding();
    }

    //private void ConfigurarBinding()
    //{
    //    if (EntradaDeDado is Entry entry)
    //    {
    //        entry.SetBinding(Entry.TextProperty, new Binding(nameof(Valor), source: this));
    //    } 
    //    else if (EntradaDeDado is DatePicker datePicker)
    //    {
    //        datePicker.SetBinding(DatePicker.DateProperty, new Binding(nameof(Valor), source: this));
    //    } 
    //    else if (EntradaDeDado is TimePicker timePicker)
    //    {
    //        timePicker.SetBinding(TimePicker.TimeProperty, new Binding(nameof(Valor), source: this));
    //    }
    //    else
    //    {
    //        CheckBox checkBox = (CheckBox)EntradaDeDado;
    //        checkBox.SetBinding(CheckBox.IsCheckedProperty, new Binding(nameof(Valor), source: this));
    //    }        
    //}
}
