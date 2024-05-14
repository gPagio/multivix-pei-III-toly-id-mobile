using CommunityToolkit.Mvvm.ComponentModel;

namespace TolyID.MVVM.Models;

public class CampoCadastroModel : ObservableObject
{    
    private string _nome;
    private object _valor;
    private Keyboard _tipoTeclado;
    private DatePicker _datePicker;

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
        set => SetProperty(ref _tipoTeclado, value);
    }

    public DatePicker DatePicker
    {
        get => _datePicker;
        set => SetProperty(ref _datePicker, value);
    }

    public object EntradaDeDado
    {
        get
        {
            if (DatePicker == null)
            {
                return TipoTeclado;
            }
                        
            return DatePicker;                   
        }        
    }

    public CampoCadastroModel(string nome, Keyboard? tipoTeclado, DatePicker? datePicker = null)
    {
        Nome = nome;
        TipoTeclado = tipoTeclado;
        DatePicker = datePicker;
    }
}
