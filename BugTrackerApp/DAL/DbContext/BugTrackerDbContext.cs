
using BugTrackerApp.Models;
using System.Data.Entity;

namespace BugTrackerApp.DAL
{
    public class BugTrackerDbContext : DbContext
    {
        public BugTrackerDbContext()
            : base("name=DefaultConnectionString")
        {
        }
        public DbSet<Bug> Bugs { get; set; }
    }
}