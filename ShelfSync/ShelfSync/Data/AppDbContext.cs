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
    public DbSet<Category> Categories { get; set; }
    public DbSet<StorageBin> StorageBins { get; set; }
    public DbSet<BinItem> BinItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "General",
                Description = "General storage category"
            }
        );


    }

}
