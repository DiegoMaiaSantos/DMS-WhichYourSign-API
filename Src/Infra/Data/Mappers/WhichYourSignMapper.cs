using DMS_WhichYourSign_API.Src.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMS_WhichYourSign_API.Src.Infra.Data.Mappers
{
    public class WhichYourSignMapper : IEntityTypeConfiguration<WhichYourSign>
    {
        public void Configure(EntityTypeBuilder<WhichYourSign> builder)
        {
            builder.ToTable("WhichYourSign");

            builder.HasKey(e => e.SignId);

            builder.Property(e => e.SignName)
                .HasColumnName("Name");

            builder.Property(e => e.InicialDate)
                .HasColumnName("InitialDate");

            builder.Property(e => e.FinalDate)
                .HasColumnName("FinalDate");
        }
    }
}
