using SQLite;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("Biometrias")]
public class Biometria
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [DisplayName("Comprimento Total")]
    public double ComprimentoTotal { get; set; }

    [DisplayName("Comprimento da Cabeça")]
    public double ComprimentoDaCabeca { get; set; }

    [DisplayName("Largura da Cabeça")]
    public double LarguraDaCabeca { get; set; }

    [DisplayName("Padrão do Escudo Cefálico")]
    public string? PadraoEscudoCefalico { get; set; }

    [DisplayName("Comprimento do Escudo Cefálico")]
    public double ComprimentoEscudoCefalico { get; set; }

    [DisplayName("Largura do Escudo Cefálico")]
    public double LarguraEscudoCefalico { get; set; }

    [DisplayName("Largura Inter-Orbital")]
    public double LarguraInterOrbital { get; set; }

    [DisplayName("Comprimento da Orelha")]
    public double ComprimentoDaOrelha { get; set; }

    [DisplayName("Comprimento da Cauda")]
    public double ComprimentoDaCauda { get; set; }

    [DisplayName("Largura da Cauda")]
    public double LarguraDaCauda { get; set; }

    [DisplayName("Comprimento do Escudo Escapular")]
    public double ComprimentoEscudoEscapular { get; set; }

    [DisplayName("Semicircunferência do Escudo Escapular")]
    public double SemicircunferenciaEscudoEscapular { get; set; }

    [DisplayName("Comprimento do Escudo Pélvico")]
    public double ComprimentoEscudoPelvico { get; set; }

    [DisplayName("Semicircunferência do Escudo Pélvico")]
    public double SemicircunferenciaEscudoPelvico { get; set; }

    [DisplayName("Largura na Segunda Cinta")]
    public double LarguraNaSegundaCinta { get; set; }

    [DisplayName("Número de Cintas")]
    public int NumeroDeCintas { get; set; }

    [DisplayName("Comprimento da Mão Sem Unha")]
    public double ComprimentoMaoSemUnha { get; set; }

    [DisplayName("Comprimento da Unha da Mão")]
    public double ComprimentoUnhaDaMao { get; set; }

    [DisplayName("Comprimento do Pé Sem Unha")]
    public double ComprimentoPeSemUnha { get; set; }

    [DisplayName("Comprimento da Unha do Pé")]
    public double ComprimentoUnhaDoPe {  get; set; }

    [DisplayName("Comprimento do Pênis")]
    public double ComprimentoDoPenis {  get; set; }

    [DisplayName("Largura da Base do Pênis")]
    public double LarguraBasePenis { get; set; }

    [DisplayName("Comprimento do Clitóris")]
    public double ComprimentoDoClitoris { get; set; }
}
