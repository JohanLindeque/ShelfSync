using System;
using ShelfSync.Entities;

namespace ShelfSync.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategories();
    Task<Category> AddCategory(Category category);
}
