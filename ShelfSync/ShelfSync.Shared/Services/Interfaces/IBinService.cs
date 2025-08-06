using System;
using ShelfSync.Shared.Entities;

namespace ShelfSync.Shared.Services.Interfaces;

public interface IBinService
{
    Task<List<StorageBin>> GetAllStorageBins();
    Task<StorageBin> GetStorageBinById(int Id);
    Task<bool> DeketeCategoryById(int Id);
    Task<StorageBin> AddStorageBin(StorageBin storageBin);
    Task<StorageBin> UpdateStorageBin(StorageBin storageBin);
}
