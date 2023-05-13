using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySolution.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Infraestructure.Configuration
{
    public class MusicConfiguration : IEntityTypeConfiguration<MusicEntity>
    {
        public void Configure(EntityTypeBuilder<MusicEntity> builder)
        {
            builder
                .ToTable("Music", schema: "dbo");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            builder
                .HasQueryFilter(h => !h.IsDeleted);

            #region default data

            builder.HasData(
                new
                {
                    Id = 1,
                    Title = "Do I Wanna Know",
                    Genre = "Rock"
                },
                new
                {
                    Id = 2,
                    Title = "Shape of My Heart",
                    Genre = "Rock"
                },
                new
                {
                    Id = 3,
                    Title = "Still loving you",
                    Genre = "Rock"
                },
                new
                {
                    Id = 4,
                    Title = "Dream on",
                    Genre = "Rock"
                }
            );
            #endregion
        }
    }
}
