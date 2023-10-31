using DMS_WhichYourSign_API.Src.Infra.Data.Entities;
using DMS_WhichYourSign_API.Src.Infra.Data.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DMS_WhichYourSign_API.Src.Infra.Data.Contexts
{
    public class WhichYourSignDBContext : DbContext  
    {
        public DbSet<WhichYourSign> WhichYourSigns { get; set; }
        public WhichYourSignDBContext(DbContextOptions<WhichYourSignDBContext> options) : base(options)
        {
        }

        private static void ApplyMappers(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WhichYourSignMapper());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyMappers(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
