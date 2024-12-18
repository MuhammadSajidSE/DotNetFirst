using college_Application.MyLooging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//remove all 4 kind of logger
//builder.Logging.ClearProviders();
//builder.Logging.AddDebug();
//builder.Logging.AddConsole();

// Add services to the container.




//working with serilog log provider
//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .WriteTo.File("Log/Log.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

//builder.Services.AddSerilog();



//Log4Net configration setting in dot net core web API

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//loolsy couple technique of dependency injection 
//first define the interface and seocnd which object will pass
builder.Services.AddScoped<IMyLogger, LogToServer>();
builder.Services.AddTransient<IMyLogger, LogToServer>();
builder.Services.AddSingleton<IMyLogger, LogToServer>();

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
