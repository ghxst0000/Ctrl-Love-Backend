
using System.Text.Json.Serialization;
using CtrlLove.Exceptions;
using CtrlLove.Hubs;
using CtrlLove.Models;
using CtrlLove.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
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
builder.Services.AddTransient<CtrlLoveService>();
builder.Services.AddTransient<IInterestService, InterestService>();
builder.Services.AddTransient<ILikeService, LikeService>();
builder.Services.AddDbContext<CtrlLoveContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSignalR();


builder.Services.AddControllers()
    .AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

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
    catch (EmailAlreadyInUseException e)
    {
        context.Response.StatusCode = 418;
        await context.Response.WriteAsync(e.Message);
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseFileServer();
app.MapHub<ChatHub>("/chatHub");

app.UseAuthorization();

app.MapControllers();

app.Run();