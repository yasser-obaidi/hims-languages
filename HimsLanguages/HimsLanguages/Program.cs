using HimsLanguages.Data;
using HimsLanguages.Data.Repo;
using HimsLanguages.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<Context>(opt => opt.UseMySQL(
    connStr
  ));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LanguagesRepo>();
builder.Services.AddScoped<LanguagesService>();
builder.Services.AddScoped<LocaleStringResourcesRepo>();
builder.Services.AddScoped<LocaleStringResourcesService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
