using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;

namespace ContosoCrafts.WebSite
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
            //Add new services here
            services.AddRazorPages();
            //Transient creates a new instance of a service every time
            services.AddTransient<JsonFileProductService>(); //lets all of asp.net know that this is a service
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //i.e Maps "privacy" to privacy page
                endpoints.MapRazorPages();

                //Mapping for /products (THE HARD WAY)
                endpoints.MapGet("/products", (context) =>
                {
                    //tell our App to Get the service "GetProducts()" which is of type <JsonFileProductService>. This returns all products
                    var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();

                    //Serializer the products into a json string that is IEnumerable of products (array of products???)
                    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);

                    //Return a response of JSON
                    return context.Response.WriteAsync(json);
                });
            });
        }
    }
}
