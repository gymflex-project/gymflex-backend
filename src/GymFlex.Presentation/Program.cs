using GymFlex.Infrastructure.Data.Context;
using GymFlex.Presentation.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppConections(builder.Configuration)
    .AddUseCases()
    .AddAndConfigureControllers(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowSpecificOrigins");
app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
