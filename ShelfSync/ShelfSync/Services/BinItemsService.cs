using System;
using Microsoft.EntityFrameworkCore;
using ShelfSync.Data;
using ShelfSync.Shared.Entities;
using ShelfSync.Shared.Services.Interfaces;

namespace ShelfSync.Services;

public class BinItemsService : IBinItemService
{
    private readonly AppDbContext _context;
    public BinItemsService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<BinItem>> GetAllBinItems(int binId)
    {
        var binItems = await _context.BinItems.Where(b => b.StorageBinId == binId).ToListAsync();
        return binItems;
    }
    public async Task<BinItem> GetBinItemById(int Id)
    {
        return await _context.BinItems.FindAsync(Id);
    }

    public async Task<BinItem> AddBinItem(BinItem binItem)
    {
        _context.BinItems.Add(binItem);
        await _context.SaveChangesAsync();

        return binItem;
    }

    public async Task<bool> DeleteBinItemById(int Id)
    {
        var binItem = await _context.BinItems.FindAsync(Id);
        if (binItem == null)
        {
            return false;
        }

        _context.BinItems.Remove(binItem);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<BinItem> UpdateBinItem(BinItem binItem)
    {
        _context.BinItems.Update(binItem);
        await _context.SaveChangesAsync();

        return binItem;
    }
}
