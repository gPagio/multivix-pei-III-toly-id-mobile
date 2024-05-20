namespace TolyID.MVVM.Models;

public class TatuCapturadoModel
{
    public DadosGeraisModel DadosGerais { get; set; } = new();
    public BiometriaModel Biometria { get; set; } = new();
    public AmostrasModel Amostras { get; set; } = new();
}

