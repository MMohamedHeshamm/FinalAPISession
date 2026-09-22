using FinalAPISession.Data;
using FinalAPISession.Helper;
using FinalAPISession.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connection
var connection = builder.Configuration.GetConnectionString("x");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

//Repo
builder.Services.AddScoped(typeof(IGeneric<>),typeof(Generic<>));
builder.Services.AddScoped<DoctorRepo>();
builder.Services.AddScoped<PatientRepo>(); 


//Auto Mapping
builder.Services.AddAutoMapper(typeof(ProfileMapping));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
