using System;
using Microsoft.EntityFrameworkCore;
using ShelfSync.Data;
using ShelfSync.Entities;
using ShelfSync.Services.Interfaces;

namespace ShelfSync.Services;

public class CategoryService : ICategoryService
{

    private readonly AppDbContext _context;
    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category> AddCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return category;
    }




}
