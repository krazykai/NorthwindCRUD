using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using NorthwindCRUD.Repository;
using NorthwindCRUD.Services;

var builder = WebApplication.CreateBuilder(args);

/* ConnectionString */
// 載入 .env 檔案
Env.Load();
// 取得連線字串
string connectionString = builder.Configuration.GetConnectionString("mssql");
// 將 .env 的環境變數代入 appsettings.json 中對應的變數
connectionString = connectionString
    .Replace("${DB_SERVER}", Environment.GetEnvironmentVariable("DB_SERVER"))
    .Replace("${DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME"))
    .Replace("${DB_USER}", Environment.GetEnvironmentVariable("DB_USER"))
    .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));

/* Add services to the container. */
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
// DbContext
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));
// Repository
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
// Service
builder.Services.AddScoped<ICustomerService, CustomerService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
