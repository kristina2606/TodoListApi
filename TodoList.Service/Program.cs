using Microsoft.EntityFrameworkCore;
using TodoList.Application;
using TodoList.Application.Repositories;
using TodoList.Application.Services;
using TodoList.Application.Services.Implementation;
using TodoList.Persistence.Data;
using TodoList.Persistence.Repositories;
using TodoList.Service.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ICurrentUser, CurrentUserProvider>();
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();
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
