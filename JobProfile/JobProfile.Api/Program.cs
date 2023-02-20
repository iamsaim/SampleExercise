using JobProfile.Api.Seed;
using JobProfile.Application.Context;
using JobProfile.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddDbContext<ApplicationContext>(option => option.UseInMemoryDatabase("JobDb"));


builder.Services.AddSwaggerGen();

builder.Services.Seed();

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
