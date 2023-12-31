using BKS.VacancyMagic.Backend.Common.Configuration;
using BKS.VacancyMagic.Backend.DAL;
using BKS.VacancyMagic.Backend.DAL.Models;
using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Mapping;
using BKS.VacancyMagic.Backend.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
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

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(VacancyProfie));

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BKS API", Version = "V1" });
    //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Description = "Please enter a valid token",
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.ApiKey,
    //    BearerFormat = "JWT",
    //    Scheme = "Bearer"
    //});
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //        {
    //            {
    //                new OpenApiSecurityScheme
    //                {
    //                    Reference = new OpenApiReference
    //                    {
    //                        Type = ReferenceType.SecurityScheme,
    //                        Id = "Bearer"
    //                    }
    //                },
    //                new string[]{}
    //            }
    //        });
});

//Register vacancy service to DI
builder.Services.AddScoped<IVacancy, SuperjobService>();
builder.Services.AddScoped<ISearch, ChadService>();

builder.Services.AddScoped<ChadService>();
builder.Services.AddScoped<SuperjobService>();

//services.AddValidatorsFromAssemblyContaining<Validator>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString(nameof(AppDbContext)));
    //options.UseOpenIddict();
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Auth/login");
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseCors("AllowAll");

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//Require for use controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
