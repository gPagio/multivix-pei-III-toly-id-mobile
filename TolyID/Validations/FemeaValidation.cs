using InputKit.Shared.Validations;
using Microsoft.Maui.Controls;

namespace TolyID.Validations;

public class FemeaValidation : BindableObject, IValidation
{
    public static readonly BindableProperty Campo1Property = BindableProperty.Create(
        nameof(Campo1),
        typeof(string),
        typeof(FemeaValidation),
        null);

    public static readonly BindableProperty Campo2Property = BindableProperty.Create(
        nameof(Campo2),
        typeof(string),
        typeof(FemeaValidation),
        null);

    // Propriedades para os campos dependentes
    public string Campo1
    {
        get => (string)GetValue(Campo1Property);
        set => SetValue(Campo1Property, value);
    }

    public string Campo2
    {
        get => (string)GetValue(Campo2Property);
        set => SetValue(Campo2Property, value);
    }

    public string Message { get; set; } = "Campo Obrigatório!";

    public bool Validate(object value)
    {
        bool campo1Preenchido = !string.IsNullOrEmpty(Campo1);
        bool campo2Preenchido = !string.IsNullOrEmpty(Campo2);
        bool campoAtualPreenchido = !string.IsNullOrEmpty((string)value);

        // Caso qualquer um dos campos dependentes esteja preenchido
        if (campo1Preenchido || campo2Preenchido)
        {
            if (campoAtualPreenchido)
            {
                Message = "Este campo não pode ser preenchido caso Comprimento do Pênis ou Largura da Base do Pênis estejam preenchidos.";
                return false;
            }
            return true; // Campo atual pode ficar vazio
        }
        else // Ambos os campos dependentes estão vazios
        {
            if (!campoAtualPreenchido)
            {
                Message = "Campo Obrigatório!";
                return false;
            }
            return true; // Campo atual preenchido, validação bem-sucedida
        }
    }
}
