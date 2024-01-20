
using Application.Abstract;
using Application.Implements;
using Domain.Model;
using Infraestructure.Interface;
using Infraestructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Transversal;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
const string AllowAllHeadersPolicy = "AllowAllHeadersPolicy";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllHeadersPolicy,
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Gestión Pruebas", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddDbContext<DBGestionPruebasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = TokenHelper.Issuer,
                ValidAudience = TokenHelper.Audience,
                //IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(TokenHelper.Secret)),
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(TokenHelper.Secret)),
                ClockSkew = TimeSpan.Zero,
            };

        })
        .AddJwtBearer("AzureAd", options =>
        {
            options.MetadataAddress = "https://login.microsoftonline.com/7a32d812-f585-4b61-9910-9f8c9712b6f7/v2.0/.well-known/openid-configuration";
            options.Audience = "61c8b3ea-cd02-4e49-b52a-525ec1584acc";
            options.Authority = "https://login.microsoftonline.com/";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudiences = builder.Configuration.GetSection("ValidAudiences").Get<string[]>(),
                ValidIssuers = builder.Configuration.GetSection("ValidIssuers").Get<string[]>()
            };
        })
        .AddPolicyScheme("B2C_OR_AAD", "B2C_OR_AAD", options =>
        {
            options.ForwardDefaultSelector = context =>
            {
                string? authorization = context.Request.Headers[HeaderNames.Authorization];
                if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
                {
                    var token = authorization["Bearer ".Length..].Trim();
                    var jwtHandler = new JwtSecurityTokenHandler();

                    return (jwtHandler.CanReadToken(token) && jwtHandler.ReadJwtToken(token).Issuer.Equals("B2C-Authority"))
                        ? "B2C" : "AzureAd";
                }
                return "AzureAd";
            };
        });

builder.Services.AddAuthorization(options =>
{
    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
        JwtBearerDefaults.AuthenticationScheme,
        "AzureAd");
    defaultAuthorizationPolicyBuilder =
        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
});

builder.Services.AddAuthorization();


//Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAspiranteService, AspiranteService>();
builder.Services.AddScoped<IPruebaSeleccionService, PruebaSeleccionService>();


//Repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAspiranteRepository, AspiranteRepository>();
builder.Services.AddScoped<IPruebaSeleccionRepository, PruebaSeleccionRepository>();

builder.Services.AddScoped<ITokenRepository, TokenRepository>();

var app = builder.Build();
app.UseCors(AllowAllHeadersPolicy);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
