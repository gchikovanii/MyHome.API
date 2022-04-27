using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyHome.Application.ConfigurationOptions;
using MyHome.Application.Jobs;
using MyHome.Application.Services.Abstraction;
using MyHome.Application.Services.Abstraction.AdvertismentAggregate;
using MyHome.Application.Services.Abstraction.CloudinaryAggregate;
using MyHome.Application.Services.Abstraction.FeatureAggregate;
using MyHome.Application.Services.Abstraction.JwtAuth;
using MyHome.Application.Services.Abstraction.UserAggregate;
using MyHome.Application.Services.Implementatioon;
using MyHome.Application.Services.Implementatioon.AdvertismentAggregate;
using MyHome.Application.Services.Implementatioon.FeatureAggregate;
using MyHome.Application.Services.Implementatioon.JwtAuth;
using MyHome.Application.Services.Implementatioon.UserAggregate;
using MyHome.Domain.Entities.UserAggregate;
using MyHome.Infrastructure.DataContext;
using MyHome.Infrastructure.Repository.Abstraction;
using MyHome.Infrastructure.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo() { Title = "MyHome.API", Version = "v1" });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Bearer Scheme"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddSingleton<IJwtAuthetificationManager>
    (new JwtAuthetificationManager(builder.Configuration.GetSection("JwtToken").Value));




builder.Services.AddHostedService<AdExpireDateJob>();
builder.Services.Configure<CloudinarySetting>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddTransient<IFeatureRepository,FeatureRepository>();
builder.Services.AddTransient<IFeatureItemRepository, FeatureItemRepository>();
builder.Services.AddTransient<IFeatureItemSelectService, FeatureItemSelectService>();
builder.Services.AddTransient<IFeatureItemSelectRepository, FeatureItemSelectRepository>();
builder.Services.AddTransient<IAdFeaturetService, AdFeaturetService>();
builder.Services.AddTransient<IAdFeatureRepository, AdFeatureRepository>();
builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(i => i.SwaggerEndpoint("/swagger/v1/swagger.json","MyHome.Api v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
