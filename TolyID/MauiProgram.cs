using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using TolyID.Infraestrutura.Database;
using Microsoft.EntityFrameworkCore;

namespace TolyID
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Adicionar o DbContext usando SQLite
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TolyIdDatabase.db");
            builder.Services.AddDbContext<TolyIdDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            return builder.Build();
        }
    }
}
