using BankingCreditSystem.Application;
using BankingCreditSystem.Persistence;
using Microsoft.OpenApi.Models;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankingCreditSystem.WebAPI", Version = "v1" });
});


// Add Application & Persistence Services
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankingCreditSystem.WebAPI v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();


