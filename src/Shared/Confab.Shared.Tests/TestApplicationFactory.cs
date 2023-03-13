using Confab.Shared.Infrastructure.Auth;
using Confab.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Confab.Shared.Tests;

//alternatywne wejscie do naszej aplikacji
public class TestApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //dzieki temu korzystamy z appsettings test
        builder.UseEnvironment("test");
    }
}