using Apartmasyon.Application;
using Apartmasyon.Infrastructure;
using Apartmasyon.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apartmasyon Management API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();