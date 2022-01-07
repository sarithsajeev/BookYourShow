using BookYourShow.Models;
using BookYourShow.Api.Repository;
using BookYourShow.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace BookYourShow.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services over here.
            services.AddDbContext<BookYourShowContext>(
                         item => item.UseSqlServer(Configuration.GetConnectionString("ConStr")));
                          item => item.UseSqlServer(Configuration.GetConnectionString("ConStr"))
                          );

            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IReservationRepo, ReservationRepo>();

            services.AddScoped<IActorRepo, ActorRepo>();
            services.AddScoped<ICrewRepo, CrewRepo>();
            services.AddScoped<ICastsRepo, CastsRepo>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            //.......................
            services.AddSwaggerGen();
            services.AddCors();
            services.AddControllers();
           
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
