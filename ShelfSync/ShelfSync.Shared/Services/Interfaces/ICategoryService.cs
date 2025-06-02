using System;
using ShelfSync.Shared.Entities;

namespace ShelfSync.Shared.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategories();
    Task<Category> AddCategory(Category category);
}
