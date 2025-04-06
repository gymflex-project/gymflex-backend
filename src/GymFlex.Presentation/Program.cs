using GymFlex.Presentation.Configurations;
using GymFlex.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppConnections(builder.Configuration)
    .AddUseCases()
    .AddAndConfigureControllers(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowSpecificOrigins");
app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Executa o seeding do banco de dados
app.UseDatabaseSeeder();

app.Run();