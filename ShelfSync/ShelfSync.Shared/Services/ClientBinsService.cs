using System;
using System.Net.Http.Json;
using ShelfSync.Shared.Entities;
using ShelfSync.Shared.Services.Interfaces;

namespace ShelfSync.Shared.Services;

public class ClientBinsService : IBinService
{
    private readonly HttpClient _httpClient;

    public ClientBinsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<List<StorageBin>> GetAllStorageBins()
    {
        var result = await _httpClient.GetFromJsonAsync<List<StorageBin>>($"api/bins/all");
        return result;
    }

    public async Task<StorageBin> GetStorageBinById(int Id)
    {
        var result = await _httpClient.GetFromJsonAsync<StorageBin>($"api/bins/{Id}");
        return result;

    }

    public async Task<StorageBin> AddStorageBin(StorageBin storageBin)
    {
        var result = await _httpClient.PostAsJsonAsync("api/bins/add", storageBin);
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadFromJsonAsync<StorageBin>() ?? storageBin;

    }

    public async Task<bool> DeketeCategoryById(int Id)
    {
        try
        {
            var result = await _httpClient.DeleteAsync($"api/bins/{Id}");
            return result.IsSuccessStatusCode;

        }
        catch (HttpRequestException)
        {
            return false;
        }
    }


    public async Task<StorageBin> UpdateStorageBin(StorageBin storageBin)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/bins/{storageBin.Id}", storageBin);
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadFromJsonAsync<StorageBin>() ?? storageBin;
    }
}
