using FinalExercis.Repositories;
using FinalExercis.Repositories.Contracts;
using FinalExercis.Services;
using FinalExercis.Services.Automapper;
using FinalExercis.Services.Contracts;
using FinalExercise.Api.Automapper;
using FinalExercise.Api.Implementations;
using FinalExercise.Context;
using FinalExercise.Dal.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDisciplineRepository, DisciplineRepository>();
builder.Services.AddScoped<IDisciplineService, DisciplineService>();
builder.Services.AddScoped<IDbWriterContext, DbWriterContext>();
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile<ApiProfile>();
    x.AddProfile<ServiceProfile>();
});

builder.Services.AddDbContext<FinalExerciseContext>(opts =>
    opts.UseNpgsql("Host=localhost;Port=5432;Database=FinalExercise;Username=postgres;Password=Qwerty123456!"));
builder.Services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<FinalExerciseContext>());
builder.Services.AddScoped<IReader>(x => x.GetRequiredService<FinalExerciseContext>());
builder.Services.AddScoped<IWriter>(x => x.GetRequiredService<FinalExerciseContext>());


builder.Services.AddControllers();
builder.Services.AddHealthChecks();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("swagger/v1/swagger.json");
    app.UseSwaggerUI();
}

app.MapHealthChecks("health");
app.MapControllers();

app.Run();
