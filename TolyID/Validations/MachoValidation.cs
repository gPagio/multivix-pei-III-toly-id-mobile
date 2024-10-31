using InputKit.Shared.Validations;

namespace TolyID.Validations;

public class MachoValidation : BindableObject, IValidation
{
    public static readonly BindableProperty CampoFemeaProperty = BindableProperty.Create(
        nameof(CampoFemea),
        typeof(string),
        typeof(MachoValidation),
        null);

    public string CampoFemea
    {
        get => (string)GetValue(CampoFemeaProperty);
        set => SetValue(CampoFemeaProperty, value);
    }

    public string Message { get; set; } = "Campo Obrigatório!";

    public bool Validate(object value)
    {
        string campoMacho = (string)value;
        bool campoFemeaPreenchido = !string.IsNullOrEmpty(CampoFemea);
        bool campoMachoPreenchido = !string.IsNullOrEmpty(campoMacho);

        if (campoFemeaPreenchido) 
        {
            if (campoMachoPreenchido)
            {
                Message = "Atenção: este campo não pode ser preenchido quando o Comprimento do Clitóris está preenchido.";
                return false; // Ambos os campos preenchidos
            }
            return true; // Apenas CampoFemea Preenchido
        }
        else
        {
            if (!campoMachoPreenchido)
            {
                Message = "Campo Obrigatório!";
                return false; // Ambos os campos vazios
            }
            return true; // Apenas CampoMacho preenchido
        }   
    }
}
