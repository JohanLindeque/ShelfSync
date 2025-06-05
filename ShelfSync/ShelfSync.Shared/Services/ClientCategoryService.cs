using System;
using System.Net.Http.Json;
using ShelfSync.Shared.Entities;
using ShelfSync.Shared.Services.Interfaces;

namespace ShelfSync.Shared.Services;

public class ClientCategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public ClientCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<Category> AddCategory(Category category)
    {
        var result = await _httpClient.PostAsJsonAsync<Category>("api/category/add", category);
        return await result.Content.ReadFromJsonAsync<Category>();
    }

    public Task<List<Category>> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<Category>($"api/category/{id}");
        return result;
    }
}
