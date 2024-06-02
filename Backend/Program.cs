using BeachApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>{
    options.AddPolicy("Cors", p =>{
        p.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
            });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<MyWorldDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
