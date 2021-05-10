using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballInfoApp.Domain.EFMapping
{
     public class MatchConfig : IEntityTypeConfiguration<Match>
     {
          public void Configure(EntityTypeBuilder<Match> builder)
          {
               //builder.HasOne(x => x.Team)
               //     .WithMany(x => x.Matches)
               //     .HasForeignKey(x => x.HomeTeamId)
               //     .HasForeignKey(x => x.AwayTeamId);
               //builder.HasOne(x => x.HomeTeam)
               //     .WithMany(t => t.HomeMatches)
               //     .HasForeignKey(m => m.HomeTeamId)
               //     .OnDelete(DeleteBehavior.NoAction);

               //builder.HasOne(x => x.AwayTeam)
               //            .WithMany(t => t.AwayMatches)
               //            .HasForeignKey(m => m.AwayTeamId)
               //            .OnDelete(DeleteBehavior.NoAction);

          }
     }
}
