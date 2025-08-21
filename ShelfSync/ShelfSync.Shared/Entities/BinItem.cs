using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelfSync.Shared.Entities;

public class BinItem
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public string? Description { get; set; }

    public required int StorageBinId { get; set; }
    [ForeignKey("StorageBinId")]
    public StorageBin StorageBin { get; set; }  = null!;
}
