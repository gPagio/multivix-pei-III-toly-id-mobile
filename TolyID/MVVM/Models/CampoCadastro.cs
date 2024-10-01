using CommunityToolkit.Mvvm.ComponentModel;

namespace TolyID.MVVM.Models;

public class CampoCadastro : ObservableObject
{    
    private string _nome;
    private View _entradaDeDado;    // Define qual View usar para capturar dados digitados pelo usuário (Entry, DatePicker etc.)

    public string Nome
    {
        get => _nome; 
        set => SetProperty(ref _nome, value); // SetProperty notifica a interface
    }

    public View EntradaDeDado
    {
        get => _entradaDeDado;
        set => SetProperty(ref _entradaDeDado, value);         
    }

    public CampoCadastro(string nome, View entradaDeDado)
    {
        Nome = nome;
        EntradaDeDado = entradaDeDado;
    }
}
