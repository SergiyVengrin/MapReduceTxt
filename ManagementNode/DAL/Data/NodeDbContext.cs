using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public sealed class NodeDbContext : DbContext
    {
        private readonly string _connectionString;

        public NodeDbContext()
        {
            _connectionString = "Host=localhost;Port=5432;Database=NodesDb;Username=postgres;Password=1234567890";
        }

        public DbSet<Entities.FileInfo> NodesInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString, options =>
            {
                options.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorCodesToAdd: new List<string> { "4060" });
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.FileInfo>().ToTable("FilesInfo");
            modelBuilder.Entity<Entities.FileInfo>().HasKey(n => n.Id);
            modelBuilder.Entity<Entities.FileInfo>().Property(n => n.Port).IsRequired();
            modelBuilder.Entity<Entities.FileInfo>().Property(n => n.FilePath).IsRequired();
            modelBuilder.Entity<Entities.FileInfo>().Property(n => n.StartIndex).IsRequired();
            modelBuilder.Entity<Entities.FileInfo>().Property(n => n.EndIndex).IsRequired();
            modelBuilder.Entity<Entities.FileInfo>().Property(n => n.DateTime).IsRequired();
        }
    }
}
