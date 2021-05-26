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
using FootballInfoApp.API.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;

namespace FootballInfoApp.API
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
               services.AddDbContext<FootballInfoAppDbContext>(optionBuilder =>
               {
                    optionBuilder.UseSqlServer(Configuration.GetConnectionString("FootballInfoAppDbContext"));
               });

               //services.AddControllers();

               services.AddControllers(options =>
               {
                    options.Filters.Add(new AuthorizeFilter());
               });

               services.AddIdentity<User, Role>(options =>
               {
                    options.Password.RequiredLength = 8;
               })
               .AddEntityFrameworkStores<FootballInfoAppDbContext>().AddDefaultTokenProviders();

               var authOptions = services.ConfigureAuthOptions(Configuration);
               services.AddJwtAuthentication(authOptions);

               services.AddScoped<IRepository, EFCoreRepository>();
               services.AddScoped<IPlayerService, PlayerService>();
               services.AddScoped<ITeamService, TeamService>();
               services.AddScoped<IStandingService, StandingService>();
               services.AddScoped<IStadiumService, StadiumService>();
               services.AddScoped<ICoachService, CoachService>();
               services.AddScoped<IMatchService, MatchService>();
               services.AddScoped<INewService, NewService>();
               services.AddScoped<ICountryService, CountryService>();
               services.AddScoped<IUserService, UserService>();
               services.AddHttpContextAccessor();

               services.AddAutoMapper(Assembly.GetExecutingAssembly());

               services.AddSwaggerGen(c =>
               {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                         Version = "v1",
                         Title = "API",
                    });
                    var securitySchema = new OpenApiSecurityScheme
                    {
                         Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                         Name = "Authorization",
                         In = ParameterLocation.Header,
                         Type = SecuritySchemeType.Http,
                         Scheme = "bearer",
                         Reference = new OpenApiReference
                         {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                         }
                    };
                    c.AddSecurityDefinition("Bearer", securitySchema);

                    var securityRequirement = new OpenApiSecurityRequirement();
                    securityRequirement.Add(securitySchema, new[] { "Bearer" });
                    c.AddSecurityRequirement(securityRequirement);
               });
          }

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

               app.UseAuthentication();
               app.UseAuthorization();

               app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
          }
     }
}
