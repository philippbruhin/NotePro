using Microsoft.EntityFrameworkCore;
using NotePro.Models;

namespace NotePro.DataStorage
{
    public class DbContextDefault : DbContext 
    {
        public virtual DbSet<Note> Notes { get; set; }

        public DbContextDefault (DbContextOptions options) 
            : base (options)
        {
        }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
