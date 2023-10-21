using BKS.VacancyMagic.Backend.Common.Configuration;
using BKS.VacancyMagic.Backend.DAL;
using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddOptions<AppSettings>().BindConfiguration(nameof(AppSettings));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BKS API", Version = "V1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]{}
                }
            });
});

//Register vacancy service to DI
builder.Services.AddScoped<IVacancy, SuperjobService>();

//services.AddValidatorsFromAssemblyContaining<Validator>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString(nameof(AppDbContext)));
    //options.UseOpenIddict();
});

//builder.Services.AddAuthorization(options =>
//{
//    options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//});

//builder.Services.AddAuthentication();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseCors("AllowAll");
app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
