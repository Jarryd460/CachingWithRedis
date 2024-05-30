using CachingWithRedis.Models;
using Microsoft.EntityFrameworkCore;

namespace CachingWithRedis.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer() 
            {
                Id = 1,
                Address = "44 Goodwill street, Atlantis, Kenya",
                DateOfBirth = new DateOnly(1994, 4, 12),
                Email = "johndoe@gmail.com",
                Firstname = "John",
                Lastname = "Doe",
                PhoneNumber = "0825344531"
            },
            new Customer()
            {
                Id = 2,
                Address = "44 Goodwill street, Atlantis, Kenya",
                DateOfBirth = new DateOnly(1997, 10, 2),
                Email = "jane@gmail.com",
                Firstname = "Jane",
                Lastname = "Doe",
                PhoneNumber = "0824544543"
            });
    }
}
