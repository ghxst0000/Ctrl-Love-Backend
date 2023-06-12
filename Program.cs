using System.Configuration;
using CtrlLove.DAL;
using CtrlLove.Exceptions;
using CtrlLove.Models;
using CtrlLove.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddDbContext<CtrlLoveContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (IdNotFoundException e)
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync(e.Message);
    }
    catch (PermissionDeniedException e)
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync(e.Message);
    }
});

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