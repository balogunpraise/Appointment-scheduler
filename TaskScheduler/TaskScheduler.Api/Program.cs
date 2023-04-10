using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskScheduler.Api;
using TaskScheduler.Api.Startup;
using TaskScheduler.Core.Entities;
using TaskScheduler.Infrastructure.Data;
using TaskScheduler.Infrastructure.Data.Repositories;
using TaskScheduler.Infrastructure.Data.Repositories.Abstractions;
using TaskScheduler.Infrastructure.Data.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomHttpContextAccessor();
builder.Services.AddIdentityService(builder.Configuration);
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<EfContext>(option => option.UseMySql(connectionString, serverVersion: ServerVersion.AutoDetect(connectionString)));
builder.Host.ConfigureEnvironment();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddSingleton<DapperContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using(var scope = scopeFactory.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseStaticHttpContext();

app.Run();
