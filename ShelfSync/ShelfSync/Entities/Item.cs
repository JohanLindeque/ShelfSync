using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelfSync.Entities;

public class Item
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }

    public required int StorageBinId { get; set; }
    [ForeignKey("StorageBinId")]
    public StorageBin StorageBin { get; set; }
}
