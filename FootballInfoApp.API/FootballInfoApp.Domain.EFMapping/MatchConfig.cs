using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballInfoApp.Domain.EFMapping
{
     public class MatchConfig : IEntityTypeConfiguration<Match>
     {
          public void Configure(EntityTypeBuilder<Match> builder)
          {

          }
     }
}
