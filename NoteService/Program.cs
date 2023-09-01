using Microsoft.Extensions.Options;
using NoteService.Entities;
using NoteService.Repository;
using NoteService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<NoteStoreDatabaseSetting>(
               builder.Configuration.GetSection(nameof(NoteStoreDatabaseSetting)));

builder.Services.AddSingleton<INoteStoreDatabaseSetting>(sp =>
    sp.GetRequiredService<IOptions<NoteStoreDatabaseSetting>>().Value);

builder.Services.AddScoped<INoteService, noteService>();
builder.Services.AddScoped<INoteRepo, NoteRepo>();

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
