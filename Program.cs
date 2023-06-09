using apiCalendar.Repository.Contratos;
using apiCalendar.Repository.Implementaciones;
using apiCalendar.Services.Contratos;
using apiCalendar.Services.Implementaciones;
using apiCalendar.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddScoped<ICalendarServices, CalendarServices>();
builder.Services.AddScoped<ICalendarRepository, CalendarRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("*"));

app.UseAuthorization();

app.MapControllers();


app.Run();

