using Microsoft.EntityFrameworkCore;
using NeuralForge.Api.Entities;

namespace NeuralForge.Api.Data
{
    public class NeuralForgeContext : DbContext
    {
        public NeuralForgeContext(DbContextOptions<NeuralForgeContext> options) : base(options) {}
        
        public DbSet<Site> Sites { get; set; }
        public DbSet<Chip> Chips { get; set; }
        public DbSet<AssemblyLine> AssemblyLines { get; set; }
        public DbSet<ProductionRecord> ProductionRecords { get; set; }
        public DbSet<DowntimeEvent> DowntimeEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Site -> Assembly Line
            modelBuilder.Entity<Site>().HasMany(s => s.AssemblyLines)
                .WithOne(a => a.Site)
                .HasForeignKey(a => a.SiteId)
                .OnDelete(DeleteBehavior.Cascade);
            //Chip -> Assembly Line
            modelBuilder.Entity<Chip>().HasMany(c => c.AssemblyLines)
                .WithOne(a => a.Chip)
                .HasForeignKey(a => a.ChipId)
                .OnDelete(DeleteBehavior.Restrict);
            //AssemblyLine -> Production Records 
            modelBuilder.Entity<AssemblyLine>().HasMany(a => a.ProductionRecords)
                .WithOne(r => r.AssemblyLine)
                .HasForeignKey(r => r.AssemblyLineId)
                .OnDelete(DeleteBehavior.NoAction);
            //AssemblyLine -> Downtime Events
            modelBuilder.Entity<AssemblyLine>().HasMany(a => a.DowntimeEvents)
                .WithOne(r => r.AssemblyLine)
                .HasForeignKey(r => r.AssemblyLineId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
