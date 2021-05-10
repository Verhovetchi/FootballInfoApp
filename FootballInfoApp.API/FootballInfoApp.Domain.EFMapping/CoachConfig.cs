using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballInfoApp.Domain.EFMapping
{
     class CoachConfig : IEntityTypeConfiguration<Coach>
     {
          public void Configure(EntityTypeBuilder<Coach> builder)
          {
               //builder.HasOne(x => x.Team)
               //     .WithMany(t => t.Coaches)
               //     .HasForeignKey(x => x.TeamId)
               //     .OnDelete(DeleteBehavior.NoAction);
          }
     }
}
