using Microsoft.EntityFrameworkCore;

namespace TaskManagementSystemApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Models.Task> Tasks { get; set; }
}