using System;
using ShelfSync.Shared.Entities;

namespace ShelfSync.Shared.Services.Interfaces;

public interface IBinItemService
{
    Task<List<BinItem>> GetAllBinItems(int binId);
    Task<BinItem> GetBinItemById(int Id);
    Task<bool> DeleteBinItemById(int Id);
    Task<BinItem> AddBinItem(BinItem binItem);
    Task<BinItem> UpdateBinItem(BinItem binItem);
}
