using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using API.Domain.Repositories;
using API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using API.Persistence;

namespace API
{
        public class Startup
        {
            public IConfiguration Configuration { get; }

            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                services.AddDbContext<AppDbContext>(options => {
                    options.UseInMemoryDatabase("supermarket-api-in-memory");
                });

                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<ICategoryService, CategoryService>();
            }

            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseMvc();
            }
        }
}
