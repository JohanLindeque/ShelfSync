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

    public async Task<List<Category>> GetAllCategories()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Category>>($"api/category/all");
        return result;
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<Category>($"api/category/{id}");
        return result;
    }


    public async Task<Category> AddCategory(Category category)
    {
        var result = await _httpClient.PostAsJsonAsync("api/category/add", category);
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadFromJsonAsync<Category>() ?? category;
    }


    public async Task<bool> DeleteCategoryById(int id)
    {
        try
        {
            var result = await _httpClient.DeleteAsync($"api/category/{id}");
            return result.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/category/{category.Id}", category);
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadFromJsonAsync<Category>() ?? category;
    }




}
