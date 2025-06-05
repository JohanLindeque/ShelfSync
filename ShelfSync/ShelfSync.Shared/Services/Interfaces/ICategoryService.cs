using System;
using ShelfSync.Shared.Entities;

namespace ShelfSync.Shared.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategories();
    Task<Category> GetCategoryById(int Id);
    Task<bool> DeleteCategoryById(int Id);
    Task<Category> AddCategory(Category category);
}
