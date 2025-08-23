using Microsoft.EntityFrameworkCore;
using Staff_Backend.Models;

namespace Staff_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<StaffModel> Staff { get; set; }
    }
}
