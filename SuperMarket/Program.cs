using SuperMarket.Data;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// add Nlog

builder.WebHost.ConfigureLogging((hostingContext, logging) =>
{
    logging.AddNLog(hostingContext.Configuration.GetSection("Logging"));
});

builder.Services.AddDbContext<SuperMarketDataBaseFirstContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SuperMarketConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();
