using FootballInfoApp.Domain;
using FootballInfoApp.Domain.Auth;
using FootballInfoApp.Domain.EFMapping.Schemas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FootballInfoApp.API
{
     public class FootballInfoAppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
     {
          public FootballInfoAppDbContext(DbContextOptions<FootballInfoAppDbContext> options) : base(options)
          {

          }

          public DbSet<Coach> Coaches { get; set; }
          public DbSet<Country> Countries { get; set; }
          public DbSet<League> Leagues { get; set; }
          public DbSet<Match> Matches { get; set; }
          public DbSet<Player> Players { get; set; }
          public DbSet<Position> Positions { get; set; }
          public DbSet<Stadium> Stadiums { get; set; }
          public DbSet<Standing> Standings { get; set; }
          public DbSet<Team> Teams { get; set; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(FootballInfoAppDbContext)));

               ApplyIdentityMapConfiguration(modelBuilder);
          }

          private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
          {
               modelBuilder.Entity<User>().ToTable("Users", SchemaConsts.Auth);
               modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConsts.Auth);
               modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConsts.Auth);
               modelBuilder.Entity<UserToken>().ToTable("UserRoles", SchemaConsts.Auth);
               modelBuilder.Entity<Role>().ToTable("Roles", SchemaConsts.Auth);
               modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConsts.Auth);
               modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConsts.Auth);
          }

     }
}
