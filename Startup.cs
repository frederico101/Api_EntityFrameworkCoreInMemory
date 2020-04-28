using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{    // Tetes aprovados
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
            services.AddControllers();
            services.AddDbContext<ProdutoContexto>(opt=>
            opt.UseInMemoryDatabase(databaseName:"Loja")
              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddTransient<IProdutoRepositorio, ProdutoRepository>();

            services.AddApiVersioning();
            services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseResponseCaching();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           }
        }
    }
}
