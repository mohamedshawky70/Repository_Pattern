using Microsoft.EntityFrameworkCore;
using Repository_Pattern.Data;
using Repository_Pattern.DTO;
using Repository_Pattern.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(
    builder.Configuration.GetConnectionString("MyConnection")
    ));
builder.Services.AddTransient(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddTransient(typeof(ALLDTO), typeof(ALLDTO));


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
