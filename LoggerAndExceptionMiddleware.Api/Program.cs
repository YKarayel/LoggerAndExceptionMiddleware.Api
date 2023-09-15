

using LoggerAndExceptionMiddleware.Api.Middlewares;
using LoggerAndExceptionMiddleware.Api.Model;
using LoggerAndExceptionMiddleware.Api.Repository;
using LoggerAndExceptionMiddleware.Api.SeriLogConfigurations;
using LoggerAndExceptionMiddleware.Api.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

SeriLogConf.SeriLogConfiguration();

//Serilog will be handle all logs now
builder.Services.AddLogging(loggingBuilder =>
	loggingBuilder.AddSerilog(dispose: true));


// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddControllers();
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
app.UseMiddleware<CustomExceptionMiddleware>();

app.Run();
