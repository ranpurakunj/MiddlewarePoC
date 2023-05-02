using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MiddlewarePractice;
using MiddlewarePractice.Extensions;
using MiddlewarePractice.Middlewares;
using MiddlewarePractice.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
RegisterServices.ConfigureServices(builder.Services, builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IplogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CORE_WEB_APIContext")??
    throw new InvalidOperationException("Connection String 'CORE_WEB_APIContext' not Found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureExceptionHandling();

app.ConfigureMiddleware();
app.Run();
