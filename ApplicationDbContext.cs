using Microsoft.EntityFrameworkCore;
using Teknorix.JobsApiFull.Models;

namespace Teknorix.JobsApiFull.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Department> Departments { get; set; }
}