using System;

namespace ShelfSync.Shared.Entities;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public ICollection<StorageBin> CreatedBins { get; set; } = [];
}

