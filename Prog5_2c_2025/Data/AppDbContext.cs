using Microsoft.EntityFrameworkCore;
using Prog5_2c_2025.Models;

namespace Prog5_2c_2025.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public DbSet<CentroVacunacion2> centrosDeVacunacion2 { get; set; }
    }
}
