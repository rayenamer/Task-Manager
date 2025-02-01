using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using gestion_taches.Data.Context;
using gestion_taches.Data.Repository;
using gestion_taches.Domain.interfaces;
using AutoMapper;
using gestion_taches.Api.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddDbContext<gestionTachesContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trace Server V1");
    });
}
else
{
    var path = Environment.GetEnvironmentVariable("service");
    var basePath = $":31644/{path}";
    app.UseExceptionHandler("/Error");
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
        c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
        {
            new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}" }
        });
    });

    var endpoint = $"/{path}/swagger/v1/swagger.json";
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(endpoint, "API V1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();