using GymFlex.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext utilizando a string de conexão do appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Obtém as origens permitidas da configuração
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Configura a política de CORS utilizando os valores do appsettings.json
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        if (allowedOrigins == null || allowedOrigins.Length == 0)
        {
            throw new ArgumentException("Allowed origins are not configured in appsettings.json.");
        }
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Adiciona os serviços à aplicação
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "GymFlex API",
        Version = "v1",
        Description = "API para o sistema GymFlex"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GymFlex API V1");
        c.RoutePrefix = "docs";
    });
}

// Habilita a política de CORS definida
app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
