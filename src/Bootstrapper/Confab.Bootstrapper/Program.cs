using Confab.Bootstrapper;
using Confab.Shared.Infrastructure;
using Confab.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureModules();

var assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var modules = ModuleLoader.LoadModules(assemblies);

builder.Services
    .AddInfrastructure(assemblies, modules)
    .AddControllers();

//dynamiczne ³adowanie modu³ow
foreach (var module in modules)
{
    module.Register(builder.Services);
}

var app = builder.Build();
app.UseInfrastructure();

//dynamiczne ³adowanie midleware
foreach (var module in modules)
{
    module.Use(app);
}

app.Logger.LogInformation($"Modules: {string.Join(", ", modules.Select(x => x.Name))}");

app.MapControllers();
app.MapGet("/", context => context.Response.WriteAsync("Confab API!"));

app.Run();