using FluentValidation;
using FluentValidation.AspNetCore;
using Org.BouncyCastle.Asn1.Cmp;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using SparkMarket.Business;
using SparkMarket.Business.MappingRules;
using SparkMarket.Business.ValidationRules.Api;
using SparkMarket.Data.Abstract;
using SparkMarket.Data.Concrete.EntityFramework.context;
using SparkMarket.Data.Concrete.UnitOfWork;
using SparkMarket.Model.DTO;
using SparkMarket.WebApi.Middleware;
using System.Collections.ObjectModel;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<SparkMarketDbContext>();
builder.Services.AddBusinessService();
builder.Services.AddFluentValidationAutoValidation();


//builder.Services.AddCors(options =>
//{
//    // Cross - Origin Resource Sharing
//    options.AddPolicy("SparkMarketPolicy", opt =>
//    {
//        // opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

//      //  opt.WithOrigins("http://localhost:5144").AllowAnyMethod().AllowAnyHeader();

//        //opt.WithOrigins("http://10.0.0.3:80").AllowAnyMethod().WithHeaders("username");

//    });

//});
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddScoped<IValidator<KategoriDTO>, KategoriValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Serilog Kütüphaneleri eklendi

//Log.Logger = new LoggerConfiguration()
//      .Enrich.FromLogContext()
//      // Buradaki MinimumLevel seviyeleri middlewaredeki log seviyesi örtüþmesi gerekiyor.
//      .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
//       // Microsoft loglarýný sadece Warning seviyesinde al
//       .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
//      //.MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Warning)
//      .WriteTo.Console()
//     .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)

// Dosyaya yaz
//  .WriteTo.Seq("http://localhost:5341")
//.WriteTo.MSSqlServer(
//    connectionString: "server=LAB202-OGRETMEN;database=LogDB;trusted_connection=true;TrustServerCertificate=true;",
//   sinkOptions: new MSSqlServerSinkOptions
//   {
//       TableName = "ApiLogs",
//       AutoCreateSqlTable = true
//   },
//   columnOptions: new ColumnOptions
//   {
//       AdditionalColumns = new Collection<SqlColumn>
//        {
//            new SqlColumn("RequestPath", SqlDbType.NVarChar, true, 512),
//            new SqlColumn("RequestBody", SqlDbType.NVarChar, true, -1),
//            new SqlColumn("ResponseBody", SqlDbType.NVarChar, true, -1),
//            new SqlColumn("StatusCode", SqlDbType.Int),
//            new SqlColumn("RequestMethod", SqlDbType.NVarChar, true, 10)
//        }
//   }
//)
//.CreateLogger();

// Serilog'u kullan
//builder.Host.UseSerilog();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("SparkMarketPolicy");
//app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseRequestResponseLogging();
app.UseAuthorization();

app.MapControllers();

app.Run();
