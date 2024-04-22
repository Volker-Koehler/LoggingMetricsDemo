using Microsoft.AspNetCore.Http.HttpResults;

using Serilog;

var path = Path.GetDirectoryName(AppContext.BaseDirectory);
Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

WebApplicationOptions webApplicationOptions = new WebApplicationOptions()
{
    ContentRootPath = path,
    Args = args
};

var builder = WebApplication.CreateBuilder(webApplicationOptions);

builder.Services.AddHttpContextAccessor();


builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.MapControllers(); 
app.Run();
