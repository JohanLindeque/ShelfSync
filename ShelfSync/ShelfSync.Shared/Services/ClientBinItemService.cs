using System;
using System.Net.Http.Json;
using ShelfSync.Shared.Entities;

namespace ShelfSync.Shared.Services.Interfaces;

public class ClientBinItemService : IBinItemService
{
    private readonly HttpClient _httpClient;

    public ClientBinItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BinItem>> GetAllBinItems(int binId)
    {
        var result = await _httpClient.GetFromJsonAsync<List<BinItem>>($"api/binItem/bin/{binId}");
        return result;
    }

    public async Task<BinItem> GetBinItemById(int Id)
    {
        var result = await _httpClient.GetFromJsonAsync<BinItem>($"api/binItem/{Id}");
        return result;
    }

    public async Task<BinItem> AddBinItem(BinItem binItem)
    {
        var result = await _httpClient.PostAsJsonAsync("api/binItem/add", binItem);
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadFromJsonAsync<BinItem>() ?? binItem;
    }

    public async Task<bool> DeleteBinItemById(int Id)
    {
        try
        {
            var result = await _httpClient.DeleteAsync($"api/binItem/{Id}");
            return result.IsSuccessStatusCode;

        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public async Task<BinItem> UpdateBinItem(BinItem binItem)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/bins/{binItem.Id}", binItem);
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadFromJsonAsync<BinItem>() ?? binItem;
    }
}
