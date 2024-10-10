using InputKit.Shared.Validations;
using Microsoft.Maui.Controls;

namespace TolyID.Validations;

public class SenhasIguaisValidation : BindableObject, IValidation
{
    // BindableProperty para a senha original
    public static readonly BindableProperty SenhaOriginalProperty = BindableProperty.Create(
        nameof(SenhaOriginal),
        typeof(string),
        typeof(SenhasIguaisValidation),
        null);

    // Propriedade para a senha original
    public string SenhaOriginal
    {
        get => (string)GetValue(SenhaOriginalProperty);
        set => SetValue(SenhaOriginalProperty, value);
    }

    public string Message { get; set; } = "As senhas não coincidem!";

    public bool Validate(object value)
    {
        if (value is string senhaConfirmacao && !string.IsNullOrEmpty(SenhaOriginal))
        {
            return senhaConfirmacao == SenhaOriginal;
        }
        return false;
    }
}
