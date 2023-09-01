using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserService.Entities;
using UserService.Repository;
using UserService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<UserStoreDatabaseSetting>(
               builder.Configuration.GetSection(nameof(UserStoreDatabaseSetting)));

builder.Services.AddSingleton<IUserStoreDatabaseSetting>(sp =>
    sp.GetRequiredService<IOptions<UserStoreDatabaseSetting>>().Value);


builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<IUserService, userService>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
