using Microsoft.Extensions.Configuration;
using System.IO;

namespace TolyID.Services.Api
{
    public class BaseApiConfiguration
    {
        protected IConfiguration Configuration { get; }

        public BaseApiConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config\\appsettings.jsonappsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
