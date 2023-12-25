using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using My_books.Data;
using My_books.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure database context and connection string
builder.Services.AddDbContext<BooksDbContext>(Options => Options.UseSqlServer(
    builder.Configuration["ConnectionStrings:AppConnectionString"]));

//configuer services

builder.Services.AddTransient<BookServices>();

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
