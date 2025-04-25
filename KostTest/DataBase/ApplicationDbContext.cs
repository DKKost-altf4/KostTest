using KostTest.models;
using Microsoft.EntityFrameworkCore;

namespace KostTest.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<mouse_cordinates> mouse_cordinates {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mouse_cordinates>()
                .Property(e => e.DataMouse)
                .HasColumnType("json");
        }
    }
}
