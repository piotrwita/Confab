using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Confab.Shared.Tests;

public static class OptionsHelper
{
    private const string AppSettings = "appsettings.test.json";

    //ladowanie konfiguracji i options customowych z pliku
    public static TOptions GetOptions<TOptions>(string sectionName) where TOptions : class, new() //konstruktor bezparametrowy
    {
        var options = new TOptions();
        var configuration = GetConfigurationRoot();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }

    public static IConfigurationRoot GetConfigurationRoot()
        => new ConfigurationBuilder()
            .AddJsonFile(AppSettings)
            //dodanie zmiennych srodowiskowych
            .AddEnvironmentVariables()
            .Build();
}
