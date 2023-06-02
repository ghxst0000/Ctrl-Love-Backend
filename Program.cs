using CtrlLove.DAL;
using CtrlLove.Exceptions;
using CtrlLove.Models;
using CtrlLove.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepository<UserModel, Guid>, UserRepository>();
builder.Services.AddSingleton<IRepository<ChatRoomModel, Guid>, ChatroomRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("AllowOrigin");

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