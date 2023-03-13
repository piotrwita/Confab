using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Confab.Shared.Tests;

public static class DbHelper
{
    private static readonly IConfiguration Configuration = OptionsHelper.GetConfigurationRoot();

    //zaladowanie options od db context
    public static DbContextOptions<T> GetOptions<T>() where T : DbContext
    => new DbContextOptionsBuilder<T>()
        .UseNpgsql(Configuration["postgres:connectionString"])//con string z pliku konfiguracyjnego
        .EnableSensitiveDataLogging()//dodatkowe logowanie
        .Options; 
}
