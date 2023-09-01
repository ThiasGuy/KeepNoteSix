using CategoryService.Models;
using CategoryService.Repository;
using CategoryService.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CategoryStoreDatabaseSetting>(
               builder.Configuration.GetSection(nameof(CategoryStoreDatabaseSetting)));

builder.Services.AddSingleton<ICategoryStoreDatabaseSetting>(sp =>
    sp.GetRequiredService<IOptions<CategoryStoreDatabaseSetting>>().Value);

builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IcategoryService, categoryService>();

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
