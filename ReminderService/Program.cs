using Microsoft.Extensions.Options;
using ReminderService.Enitities;
using ReminderService.Repository;
using ReminderService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ReminderStoreDatabaseSetting>(
               builder.Configuration.GetSection(nameof(ReminderStoreDatabaseSetting)));

builder.Services.AddSingleton<IReminderStoreDatabaseSetting>(sp =>
    sp.GetRequiredService<IOptions<ReminderStoreDatabaseSetting>>().Value);

builder.Services.AddScoped<IReminderRepo, ReminderRepo>();
builder.Services.AddScoped<IreminderService, reminderService>();

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
