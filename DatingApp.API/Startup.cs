using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DatingApp.API
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
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

           //app.UseHttpsRedirection();

        //    Aber wie ich schon sagte, ist es früh im Kurs und wir werden einfach damit fortfahren, 
        //    jeden Ursprung für die Entwicklung zu erlauben.
        //     Und am Ende des Kurses werden wir uns die Sicherheit genauer ansehen und dann die Verriegelung betrachten.
        //     unten in unserer Anwendung.
        //     Aber bitte machen Sie sich keine Sorgen über die frühen Phasen, in denen es so aussieht, 
        //      als wären wir in eine ziemlich lockere Situation geraten.
        //     Sicherheitsrichtlinien.
        //     Es ist völlig in Ordnung für die Entwicklung und wenn es um die Veröffentlichung in diesem Bereich geht, werden wir uns näher kommen.
        //     Schau dir an, was wir sicherheitsrelevant machen.
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
        }
    }
}
