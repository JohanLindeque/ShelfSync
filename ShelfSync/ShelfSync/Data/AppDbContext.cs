using System;
using Microsoft.EntityFrameworkCore;
using ShelfSync.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ShelfSync.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // dbsets = tables in db
    // public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<StorageBin> StorageBins { get; set; }
    public DbSet<Item> BinItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed dummy data
        // modelBuilder.Entity<User>().HasData(
        //     new User
        //     {
        //         Id = 1,
        //         Name = "Admin User",
        //         Surname = "Tester",
        //         Email = "admin@example.com",
        //         CreatedAt = DateTime.UtcNow
        //     }
        // );

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "General",
                Description = "General storage category"
            }
        );
        // // Seed Identity user
        // var hasher = new PasswordHasher<IdentityUser>();
        // var adminUser = new IdentityUser
        // {
        //     Id = "123e4567-e89b-12d3-a456-426614174000",
        //     UserName = "admin@test.com",
        //     NormalizedUserName = "ADMIN@TEST.COM",
        //     Email = "admin@test.com",
        //     NormalizedEmail = "ADMIN@TEST.COM",
        //     EmailConfirmed = true,
        //     SecurityStamp = "12345678-1234-1234-1234-123456789012"
        // };
        // adminUser.PasswordHash = hasher.HashPassword(adminUser, "P@ssword123!");
        // modelBuilder.Entity<IdentityUser>().HasData(adminUser);



    }

}
