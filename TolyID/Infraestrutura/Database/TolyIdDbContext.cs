using Microsoft.EntityFrameworkCore;
using TolyID.MVVM.Models;

namespace TolyID.Infraestrutura.Database;

public class TolyIdDbContext : DbContext
{
    public DbSet<TatuModel> Tatu { get; set; }
    public DbSet<CapturaModel> Captura { get; set; }
    public DbSet<DadosGeraisModel> DadosGerais { get; set; }
    public DbSet<FichaAnestesicaModel> FichaAnestesica { get; set; }
    public DbSet<BiometriaModel> Biometria { get; set; }
    public DbSet<AmostrasModel> Amostras { get; set; }
    public DbSet<ParametroFisiologicoModel> ParametroFisiologico { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // relacionamento 1:N 
        modelBuilder.Entity<TatuModel>()
            .HasMany(tatu => tatu.Capturas)             // Um tatu pode ter várias capturas
            .WithOne()                                  // Cada captura pertence a um tatu
            .HasForeignKey(captura => captura.TatuId)   // Definindo a chave estrangeira em CapturaModel
            .OnDelete(DeleteBehavior.Cascade);          // Definindo operação de cascata em deleção

        modelBuilder.Entity<CapturaModel>()
            .HasOne(captura => captura.DadosGerais)
            .WithOne()
            .HasForeignKey<CapturaModel>(captura => captura.DadosGeraisId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CapturaModel>()
            .HasOne(captura => captura.FichaAnestesica)
            .WithOne()
            .HasForeignKey<CapturaModel>(captura => captura.FichaAnestesicaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CapturaModel>()
            .HasOne(captura => captura.Biometria)
            .WithOne()
            .HasForeignKey<CapturaModel>(captura => captura.BiometriaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CapturaModel>()
            .HasOne(captura => captura.Amostras)
            .WithOne()
            .HasForeignKey<CapturaModel>(captura => captura.AmostrasId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FichaAnestesicaModel>()
            .HasMany(ficha => ficha.ParametrosFisiologicos)
            .WithOne()
            .HasForeignKey(parametro => parametro.FichaAnestesicaId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=TolyIdDatabase.db");
        }
    }
}
