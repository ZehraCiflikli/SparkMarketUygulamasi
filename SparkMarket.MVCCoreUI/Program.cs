using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Data.Abstract;
using SparkMarket.Data.Concrete.EntityFramework.repository;
using SparkMarket.Business;
using SparkMarket.Infrastructure.Interceptors;
using SparkMarket.Data.Concrete.EntityFramework.context;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;

using SparkMarket.Business.MappingRules;
using SparkMarket.Data.Concrete.UnitOfWork;
using SparkMarket.MVCCoreUI.Filters;
using SparkMarket.Business.ValidationRules.Areas.AdminPanel;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;
using FluentValidation;
using SparkMarket.Model.ViewModel.Front;
using SparkMarket.Business.ValidationRules.Front;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Configuration;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Infrastructure.CrossCuttingConcern.Comunication;
using SparkMarket.MVCCoreUI.Middlewares;
using SparkMarket.MVCCoreUI.Models;
using Microsoft.AspNetCore.SignalR;
namespace SparkMarket.MVCCoreUI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Banka  Hasan 
            // Menu   Hasan
            //-----------------------------
            // KDV
            // MenuYetki   Zehra
            //------------------------------
            // Kullanýcýlar    Fatih
            // Rol - Hazýr
            // KullanýcýRol iþleyiþi Kullanýcýlara eklenecek
            //------------------------------
            // Fiyat Tipi       Sena
            // ödeme Türü
            // Marka 
            // Kategoriler 
            //--------------------------------
            // RabbitMQ ile Rapor Ekraný Efkan 
            //---------------------------------
            //---------------------------------

            // Ürün Sayfasý 
            // Sinan

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            builder.Services.AddScoped<AuditInterceptor>();

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed(_ => true));
            });

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            builder.Services.AddDbContext<SparkMarketDbContext>();

            //builder.Services.AddDbContext<SparkMarketDbContext>(options =>
            //{
            //    options.UseSqlServer("server=LAB202-OGRETMEN;database=SparkMarketDB;trusted_connection=true;TrustServerCertificate=true;").AddInterceptors(new AuditInterceptor());

            //});

            // Validation
            builder.Services.AddSingleton<MailIslemleri>();
            builder.Services.AddBusinessService();
            //builder.Services.AddScoped<IBankaRepository, EfBankaRepository>();
            // IOC Container // Ninject, Castle Windsor,
            builder.Services.AddSession();
            builder.Services.AddScoped<ISessionManager, SessionManager>();

            builder.Services.AddSingleton<IUserConnectionManager, UserConnectionManager>();


            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddTransient<IValidator<LoginVm>, LoginVmValidator>();
            builder.Services.AddTransient<IValidator<KullniciSignupVm>, KullaniciSignupValidator>();
            builder.Services.AddSignalR();
            // CACHE
            //builder.Services.AddMemoryCache();
            //builder.Services.AddResponseCaching();

            //builder.Services.AddStackExchangeRedisCache(options =>
            //{

            //    options.Configuration = "10.0.0.1,defaultDatabase=0,password=1234";
            //    options.InstanceName = "SUNUCUINSTANCE";

            //});

            //  Another Redis Desktop Manager


            //  builder.Services.AddDistributedMemoryCache();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

         //   string logfile = Path.Combine(Directory.GetCurrentDirectory(), "loglar.txt");

            //app.UseMiddleware<GlobalExceptionHandler>(logfile);
            //   app.UseMiddleware<RequestResponseLogHandler>();
            app.UseRouting();


            app.UseAuthorization();



            // AREA  

            app.MapControllerRoute(
      name: "area",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
     );



            // MAIN SITE
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapHub<RaporHub>("/RaporHub");

            app.Run();




        }
    }
}
