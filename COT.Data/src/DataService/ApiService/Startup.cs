using CoreLibrary.Interfaces;
using CoreLibrary.Services;
using DataLibrary.Interfaces;
using DataLibrary.Models;
using DataLibrary.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services;

namespace ApiService
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
            services.AddDbContext<CotDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CotData")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();

            services.AddScoped<ICotDataContext, CotDataContext>();
            services.AddScoped<IRawCotDataService, RawCotDataService>();
            services.AddScoped<IRubDataService, RubDataService>();
            services.AddScoped<IChfDataService, ChfDataService>();
            services.AddScoped<IBtcDataService, BtcDataService>();
            services.AddScoped<IEurDataService, EurDataService>();
            services.AddScoped<IGbpDataService, GbpDataService>();
            services.AddScoped<ICadDataService, CadDataService>();
            services.AddScoped<IJpyDataService, JpyDataService>();
            services.AddScoped<IUsdDataService, UsdDataService>();
            services.AddScoped<IGoldDataService, GoldDataService>();
            services.AddScoped<ISilverDataService, SilverDataService>();
            services.AddScoped<INatGasDataService, NatGasDataService>();
            services.AddScoped<ICrudeOilDataService, CrudeOilDataService>();
            services.AddScoped<INzdDataService, NzdDataService>();
            services.AddScoped<IAudDataService, AudDataService>();
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IProcessDataService, ProcessDataService>();
            services.AddSingleton<IDownloadRawCotData, DownloadRawCotData>();
            services.AddSingleton<IFilterData, FilterData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
