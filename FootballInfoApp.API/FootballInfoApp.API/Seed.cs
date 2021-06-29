using System.Linq;
using System.Threading.Tasks;
using FootballInfoApp.Domain.Auth;
using Microsoft.AspNetCore.Identity;

namespace FootballInfoApp.API
{
     public class Seed
     {    
          public static async Task SeedUsers(UserManager<User> userManager)
          {
               if (!userManager.Users.Any())
               {
                    var user = new User()
                    {
                         UserName = "admin",
                         Email = "info_barca@mail.ru",
                    };

                    await userManager.CreateAsync(user, "qwerty123");
               }
          }
     }
}
