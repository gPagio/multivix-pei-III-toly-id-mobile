using CommunityToolkit.Mvvm.ComponentModel;

namespace TolyID.MVVM.Models;

public class CampoCadastroModel : ObservableObject
{    
    private string _nome;
    private object _valor;
    private View _entradaDeDado;

    public string Nome
    {
        get => _nome; 
        set => SetProperty(ref _nome, value); //SetProperty notifica a interface
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
    }
}
