using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BookingCatalog.Data;
using BookingCatalog.Repositories;

namespace ProductCatalog
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddMvc();
            services.AddResponseCompression();

            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<BookingRepository, BookingRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            app.UseCors(
                options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );


            app.UseMvc();
            app.UseResponseCompression();
        }
    }
}
