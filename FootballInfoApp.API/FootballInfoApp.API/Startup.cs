using System.Reflection;
using FootballInfoApp.Domain.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Authorization;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Implementations;
using FootballInfoApp.API.Repositories.Implementations;

namespace FootballInfoApp.API
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
               services.AddControllers();

               services.AddSwaggerGen();
               
               services.AddDbContext<FootballInfoAppDbContext>(optionBuilder =>
               {
                    optionBuilder.UseSqlServer(Configuration.GetConnectionString("FootballInfoAppDbContext"));
               });

               services.AddIdentity<User, Role>(options =>
               {
                    options.Password.RequiredLength = 8;
               })
               .AddEntityFrameworkStores<FootballInfoAppDbContext>();

               //services.AddControllers(options =>
               //{
               //     options.Filters.Add(new AuthorizeFilter());
               //});

               services.AddScoped<IRepository, EFCoreRepository>();
               services.AddScoped<IPlayerService, PlayerService>();
               services.AddScoped<ITeamService, TeamService>();


               services.AddAutoMapper(Assembly.GetExecutingAssembly());
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }

               app.UseSwagger();

               app.UseSwaggerUI(c =>
               {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               });

               app.UseHttpsRedirection();
               

               app.UseRouting();

               app.UseStaticFiles();
               app.UseDefaultFiles();

               app.UseAuthorization();

               app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
          }
     }
}
