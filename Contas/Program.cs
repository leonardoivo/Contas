using Contas.Domain.Interfaces;
using Contas.Service.Interfaces;
using Contas.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContaRepository, Contas.Infrastructure.Repositories.ContaRepository>();
builder.Services.AddScoped<IContaService, ContaService>();

var app = builder.Build();

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

startup.Configure(app, builder.Environment);
using IHost host = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
