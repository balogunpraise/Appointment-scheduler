using TaskScheduler.Api.Startup;
using TaskScheduler.Core.Application;
using TaskScheduler.Infrastructure.Data;
using TaskScheduler.Infrastructure.Data.Repositories.Abstractions;
using TaskScheduler.Infrastructure.Data.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Host.ConfigureEnvironment();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddSingleton<DapperContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
var httpcontext = new HttpContextAccessor();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Current.SetHttpContextAccessor(httpcontext);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
