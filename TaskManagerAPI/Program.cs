using TaskManagerAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<TaskService>();

var app = builder.Build();

app.MapOpenApi();
app.MapControllers();

app.Run();
