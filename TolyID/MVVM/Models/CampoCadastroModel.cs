using CommunityToolkit.Mvvm.ComponentModel;

namespace TolyID.MVVM.Models;

public class CampoCadastroModel : ObservableObject
{    
    private string _nome;
    private object _valor;
    private object _entradaDeDado;

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

    public object EntradaDeDado
    {
        get => _entradaDeDado;
        set => SetProperty(ref _entradaDeDado, value);         
    }

    public CampoCadastroModel(string nome, object entradaDeDado)
    {
        Nome = nome;
        EntradaDeDado = entradaDeDado;
    }
}
