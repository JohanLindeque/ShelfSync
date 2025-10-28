using System;
using ShelfSync.Shared.Entities;

namespace ShelfSync.Shared.Services.Interfaces;

public interface IBarcodeService
{
    Task<StorageBin> GenerateBarcodee(StorageBin storageBin);

}
