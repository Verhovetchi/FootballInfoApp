using System;
using System.Threading.Tasks;
using FootballInfoApp.Domain.Auth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FootballInfoApp.API.Infrastructure.Extensions
{
     public static class HostExtensions
     {
          public static async Task SeedData(this IHost host)
          {
               using (var scope = host.Services.CreateScope())
               {
                    var services = scope.ServiceProvider;
                    try
                    {
                         var context = services.GetRequiredService<FootballInfoAppDbContext>();
                         var userManager = services.GetRequiredService<UserManager<User>>();
                         context.Database.Migrate();

                         //await Seed.SeedPublishers(context);
                         //await Seed.SeedBooks(context);
                         await Seed.SeedUsers(userManager);
                    }
                    catch (Exception ex)
                    {
                         var logger = services.GetRequiredService<ILogger<Program>>();
                         logger.LogError(ex, "An error occured during migration");
                    }
               }
          }
     }
}
