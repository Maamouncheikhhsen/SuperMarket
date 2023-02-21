using SuperMarket.Data;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;
using _Eaton_IMRSYS_Kernel.Middlewares;
using SuperMarket.Services;
using SuperMarket.Interfaces;
using SuperMarket.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(typeof(IProductService<>), typeof(ProductService<>));
builder.Services.AddScoped<ICategoryService<CategoryEntity>, CategoryService>();
builder.Services.AddScoped<IStockService<StockEntity>, StockService<StockEntity>>();
builder.Services.AddScoped<IStockProductService<StockProductEntity>, StockProductService<StockProductEntity>>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});




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

builder.Services.AddDbContext<SuperMarketDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SuperMarketConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();





app.Run();
