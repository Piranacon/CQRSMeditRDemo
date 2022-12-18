using CQRSMeditRDemo.Models;
using Microsoft.EntityFrameworkCore;
namespace CQRSMeditRDemo.Data;

public class DbContextClass : DbContext
{
    protected readonly IConfiguration _configuration;

    public DbContextClass(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<StudentDetails> Students { get; set; }
}

