using Microsoft.EntityFrameworkCore;
using School.Contract.Repositories;
using School.Contract.Services;
using School.Data.context;
using School.Data.Repositories;
using School.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentServices, StudentServices>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddTransient<ITeacherServices, TeacherServices>();

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
