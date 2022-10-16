using Confab.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure()
    .AddControllers();

var app = builder.Build();

app.UseInfrastructure();

app.Run();