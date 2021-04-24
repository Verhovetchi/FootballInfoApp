using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballInfoApp.Domain.EFMapping
{
     class TeamConfig : IEntityTypeConfiguration<Team>
     {
          public void Configure(EntityTypeBuilder<Team> builder)
          {
               //builder.HasOne(x => x.Stadium)
               //     .WithOne(x => x.Team)
               //     .HasForeignKey<Stadium>(x => x.Id);

               //builder.HasOne(x => x.Logo)
               //     .WithOne(x => x.Team)
               //     .HasForeignKey<Logo>(x => x.Id);
          }
     }
}
