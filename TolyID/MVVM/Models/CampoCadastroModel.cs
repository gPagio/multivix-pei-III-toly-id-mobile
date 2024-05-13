using CommunityToolkit.Mvvm.ComponentModel;

namespace TolyID.MVVM.Models;

public class CampoCadastroModel : ObservableObject
{    
    private string _nome;
    private object _valor;
    private Keyboard _tipoTeclado;

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

    public Keyboard TipoTeclado
    {
        get => _tipoTeclado;
    }

    public CampoCadastroModel(string nome, object valor)
    {
        Nome = nome;
        Valor = valor;  
        DefineTipoTeclado(valor);
    }

    private void DefineTipoTeclado(object valor)
    {
        if (valor is int || valor is double)
        {
            _tipoTeclado = Keyboard.Numeric;
        }
        else
        {
            _tipoTeclado = Keyboard.Default; 
        }
    }
}
