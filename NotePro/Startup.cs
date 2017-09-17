using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotePro.DataStorage;
using NotePro.Services;

namespace NotePro
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
            services.AddDbContext<DbContextDefault>(
                options => options.UseInMemoryDatabase(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<INoteData, NoteData>();
            services.AddTransient<INoteSort, NoteSort>();
            services.AddTransient<DataGenerator, DataGenerator>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                ConfigureDevelopment(app);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureDevelopment(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                DbContextDefault dbcontext = serviceScope.ServiceProvider.GetService<DbContextDefault>();
                serviceScope.ServiceProvider.GetService<DataGenerator>().CreateSampleData(dbcontext);
            }
        }
    }
}
