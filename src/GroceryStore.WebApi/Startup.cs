using GroceryStore.Adapter.SqlServerRepository;
using GroceryStore.Boundary.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GroceryStore.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private const string sqlServer = "SqlServer";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(p =>
            {
                p.EnableEndpointRouting = false;

                // Whether to consider ACCEPT header from browser, by default false, to return default type
                //p.RespectBrowserAcceptHeader = true;
            })
                // Adds XML serialization Requires 1. Accept 2. AddXmlSerializerFormatters 3. ObjectResult returned from controller
                .AddXmlSerializerFormatters();

            services.AddDbContext<SqlServerDbContext>(opt =>
                opt.UseInMemoryDatabase("GroceryStore"));

            services.AddScoped<CategoryRepository, CategorySqlServerRepository>();
            services.AddScoped<ProductRepository, ProductSqlServerRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Grocery store");
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
