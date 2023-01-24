using Bilet2._2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bilet2._2.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
      public DbSet<TeamMember> teamMembers { get; set; }
    }
}
