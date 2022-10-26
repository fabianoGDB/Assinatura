using AssinaturaDigital.Model;
using AssinaturaDigital.Repositories;
using AssinaturaDigital.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<DbConfiguration>(builder.Configuration.GetSection("Default"));

builder.Services.AddScoped<IAssinaturaService, AssinaturaService>();

builder.Services.AddScoped<IAssinaturaRepository, AssinaturaRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
