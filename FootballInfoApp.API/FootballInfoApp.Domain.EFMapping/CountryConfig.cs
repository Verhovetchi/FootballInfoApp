using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballInfoApp.Domain.EFMapping
{
     class CountryConfig : IEntityTypeConfiguration<Country>
     {
          public void Configure(EntityTypeBuilder<Country> builder)
          {
               //builder.HasOne(x => x.Flag)
               //     .WithOne(x => x.Country)
               //     .HasForeignKey<Flag>(x => x.Country);
          }
     }
}
