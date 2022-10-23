using Confab.Bootstrapper;
using Confab.Shared.Infrastructure;

var assemblies = ModuleLoader.LoadAssemblies();
var modules = ModuleLoader.LoadModules(assemblies);

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure() 
    .AddControllers();

//dynamiczne ³adowanie modu³ow
foreach(var module in modules)
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