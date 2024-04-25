using Kashtanka.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Kashtanka.Api.Dal;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
    public DbSet<Pet> Pets { get; set; }
}