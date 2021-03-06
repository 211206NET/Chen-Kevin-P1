using DL;
using BL;
using Serilog;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering out deps here for dependency injection
builder.Services.AddScoped<IRepo>(ctx => new DBRepo
    (builder.Configuration.GetConnectionString("CSDB")));
builder.Services.AddScoped<IBL, CBL>();

//Setting up Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logFile.txt")
    .CreateLogger();



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
