using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public sealed class NodeDbContext : DbContext
    {
        public NodeDbContext(DbContextOptions<NodeDbContext> options) : base(options)
        { }

        public DbSet<Entities.FileInfo> NodesInfo { get; set; }


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
