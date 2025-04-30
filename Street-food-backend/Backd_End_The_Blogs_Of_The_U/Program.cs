using Backd_End_The_Blogs_Of_The_U.Utils;
using sib_api_v3_sdk.Client;
using System.Reflection;
using The_Blogs_Of_The_U.Domain.Core.Extensions;
using The_Blogs_Of_The_U.Infrastructure;
using The_Blogs_Of_The_U.Infrastructure.MySqlDb.Settings;
// using Microsoft.AspNetCore.Authentication.JwtBearer; // <-- Comentado: Librer�a de autenticaci�n JWT
// using Microsoft.IdentityModel.Tokens; // <-- Comentado: Para manejo de tokens
// using System.Text; // <-- Comentado: Para encoding (se usa en JWT)

var builder = WebApplication.CreateBuilder(args);

Configuration.Default.ApiKey.Add("api-key", builder.Configuration["BrevoApi:ApiKey"]);

var config = builder.Configuration;

// Configurar CORS (seguridad para APIs)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Carga de configuraci�n (comentado porque ya se carga autom�ticamente)
// builder.Configuration.AddJsonFile("appsettings.json");

/**************************************************************
 * SECCI�N DE SEGURIDAD JWT - COMENTADA
 **************************************************************/
/*
// Configuraci�n de JWT (autenticaci�n por tokens)
var secretKey = builder.Configuration.GetSection("JwtSettings").GetSection("SecretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false; // No requerir HTTPS (no recomendado en producci�n)
    config.SaveToken = true; // Guardar token en propiedades
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Validar firma
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes), // Clave secreta
        ValidateIssuer = false, // No validar emisor
        ValidateAudience = false // No validar audiencia
    };
});
*/

builder.Services.AddControllers();

// Configuraci�n de MySQL (sin relaci�n directa con seguridad JWT)
builder.Services.Configure<MySqlSettings>((IConfiguration)StaticAttributes.GetMySqlAttributes(config));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.Load("Backd_End_The_Blogs_Of_The_U"));
builder.Services.AddAutoMapper(Assembly.Load("The_Blogs_Of_The_U.Infrastructure"));
builder.Services.AddDomainServices().AddPersistence();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Seguridad: Redirecci�n a HTTPS

app.UseCors("AllowAllOrigins"); // Pol�tica CORS

// ��������������
// Servir el front-end est�tico
app.UseDefaultFiles();    // Busca wwwroot/index.html por defecto
app.UseStaticFiles();     // Sirve todos los archivos est�ticos en wwwroot

// Si la ruta no coincide con un controlador, devolvemos index.html
app.MapFallbackToFile("index.html");
// ��������������

/**************************************************************
 * MIDDLEWARES DE SEGURIDAD - COMENTADOS
 **************************************************************/
// app.UseAuthentication(); // <-- Middleware de autenticaci�n (JWT)
// app.UseAuthorization();  // <-- Middleware de autorizaci�n (roles/permisos)

app.MapControllers();

app.Run();