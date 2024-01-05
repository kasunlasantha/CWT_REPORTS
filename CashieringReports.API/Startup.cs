using CashieringReports.Core.ApplicationServices;
using CashieringReports.Core.ApplicationServices.Services;
using CashieringReports.Core.DomainServices;
using CashieringReports.Infrastructure;
using CashieringReports.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositPaymentService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DBContextCore>(options =>
                        options.UseOracle(Configuration.GetConnectionString("ConnectionString"), b => b.UseOracleSQLCompatibility("11")));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://localhost:4200", "http://hq-test-cn-bill-db:8091", "https://hq-test-cn-bill-db:8091", "http://hq-test-cn-bill-db:8095", "https://hq-test-cn-bill-db:8095", "https://hq-test-csh-app:443", "https://hq-test-csh-app", "https://hq-test-csh-que:8096", "https://hq-test-csh-que", "https://hq-test-csh-que:443", "https://cashieruat.slt.com.lk", "https://HQ-CSH-FRT-APP1", "http://HQ-CSH-FRT-APP1", "https://HQ-CSH-FRT-APP2", "http://HQ-CSH-FRT-APP2","https://cashier1.slt.com.lk", "https://cashier2.slt.com.lk")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddScoped<IDatabaseContext, DBContextCore>();

            services.AddScoped<IReportdataService, ReportdataService>();
            services.AddScoped<IReportDataRepository, ReportDataRepository>();

            services.AddScoped<IMISCService, MISCService>();
            services.AddScoped<IMISCRepository, MISCRepository>();

            services.AddScoped<ICenterService, CenterService>();
            services.AddScoped<ICenterRepository, CenterRepository>();

            services.AddScoped<ICRMService, CRMService>();
            services.AddScoped<ICRMRepository, CRMRepository>();

            services.AddScoped<IERPService, ERPService>();
            services.AddScoped<IERPRepository, ERPRepository>();

            services.AddScoped<ISLTService, SLTService>();
            services.AddScoped<ISLTRepository, SLTRepository>();

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IGlobalService, GlobalService>();
            services.AddScoped<IGlobalRepository, GlobalRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsApi");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
