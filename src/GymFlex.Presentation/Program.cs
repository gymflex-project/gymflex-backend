using GymFlex.Presentation.Configurations;
using GymFlex.Presentation.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppConnections(builder.Configuration)
    .AddUseCases()
    .AddAndConfigureControllers(builder.Configuration)
    .AddAndConfigureAuth();

var app = builder.Build();

app.UseCors("AllowSpecificOrigins");
app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapIdentityApi<IdentityUser>();

// Executa o seeding do banco de dados
app.UseDatabaseSeeder();

app.Run();