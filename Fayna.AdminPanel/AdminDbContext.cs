using Fayna.AdminPanel.models;
using Microsoft.EntityFrameworkCore;

namespace Fayna.AdminPanel
{
    internal class AdminDbContext :DbContext
    {

        public AdminDbContext(DbContextOptions<AdminDbContext> options): base(options) {
        
        }

        public virtual DbSet<Stickers> Stickers { get; set; } = null!;
        public virtual DbSet<StickersGroup> StickersGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {


            if (!optionsBuilder.IsConfigured) {
               
                optionsBuilder.UseNpgsql(connectionString);
            }
        
        }



    }
}
