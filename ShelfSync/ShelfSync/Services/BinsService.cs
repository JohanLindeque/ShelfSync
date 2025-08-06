using System;
using Microsoft.EntityFrameworkCore;
using ShelfSync.Data;
using ShelfSync.Shared.Entities;
using ShelfSync.Shared.Services.Interfaces;

namespace ShelfSync.Services;

public class BinsService : IBinService
{
    private readonly AppDbContext _context;
    public BinsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StorageBin>> GetAllStorageBins()
    {
        var storageBins = await _context.StorageBins.ToListAsync();
        return storageBins;
    }

    public async Task<StorageBin> AddStorageBin(StorageBin storageBin)
    {
        _context.StorageBins.Add(storageBin);
        await _context.SaveChangesAsync();

        return storageBin;

    }

    public async Task<StorageBin> GetStorageBinById(int Id)
    {
        return await _context.StorageBins.FindAsync(Id);

    }


    public async Task<bool> DeketeCategoryById(int Id)
    {
        var storageBin = await _context.StorageBins.FindAsync(Id);
        if (storageBin == null)
        {
            return false;
        }

        _context.StorageBins.Remove(storageBin);
        await _context.SaveChangesAsync();
        return true;

    }



    public async Task<StorageBin> UpdateStorageBin(StorageBin storageBin)
    {
        _context.StorageBins.Update(storageBin);
        await _context.SaveChangesAsync();
        return storageBin;
    }



}
