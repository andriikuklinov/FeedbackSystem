using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ModuleEntity = Module.GRPC.Data.Entities.Module;

namespace Module.GRPC.Data
{
    public class ModuleContext: DbContext
    {
        public DbSet<ModuleEntity> Modules { get; set; }

        public ModuleContext(DbContextOptions<ModuleContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleEntity>().HasKey(module => module.Id);
            modelBuilder.Entity<ModuleEntity>().Property(module => module.Name).IsRequired();

            modelBuilder.Entity<ModuleEntity>().HasData(new List<ModuleEntity>()
            {
                new ModuleEntity(){ Id=1, Name="First module" },
                new ModuleEntity(){ Id=2, Name="Second module" },
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
