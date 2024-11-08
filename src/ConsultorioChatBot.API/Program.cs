using ConsultorioChatBot.Api.Configuration;
using ConsultorioChatBot.Api.Extensions;
using ConsultorioChatBot.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

var redisConfiguration = builder.Configuration.GetSection("Redis")["ConnectionString"];
var redis = ConnectionMultiplexer.Connect(redisConfiguration);

builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

builder.Services.AddControllers();

builder.Services.AddDbContext<ConsultorioDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ConsultorioChatBot.Data"));
});

builder.Services.AddIdentityConfiguration(builder.Configuration);

//builder.Services.AddAutoMapper(typeof(Startup));

builder.Services.WebApiConfig();

builder.Services.AddSwaggerConfig();

builder.Services.ResolveDependencies();

//builder.Services.AddSwaggerGen();

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseDeveloperExceptionPage();

app.UseMiddleware<ExceptionMiddleware>();

app.UseMvcConfiguration();

app.UseSwaggerConfig(provider);

app.Run();
