using Microsoft.EntityFrameworkCore;
using Models.Entity;

namespace DataLayer
{
    public class ProxyDbContext : DbContext
    {
        private readonly string _connectionString;
        
        public ProxyDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public ProxyDbContext(DbContextOptions<ProxyDbContext> options) : base(options)
        {
        }
        
        public DbSet<Proxy> Proxies { get; set; }

        public DbSet<Site> Sites { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proxy>().HasIndex(e => new {e.Ip, e.Port}).IsUnique();

            base.OnModelCreating(modelBuilder);
            
        }
    }
}