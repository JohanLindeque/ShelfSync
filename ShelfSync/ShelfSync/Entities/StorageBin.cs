using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelfSync.Entities;

public class StorageBin
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }


    public required int CategoryID { get; set; }
    [ForeignKey("CategoryID")]
    public Category Category { get; set; }


    public required DateTime CratedAt { get; set; }
    public required int CreatedBy { get; set; }
    [ForeignKey("CreatedBy")]
    public User CreatedByUser { get; set; }

    public DateTime ModifiedAt { get; set; }
    public int ModifiedBy { get; set; }
    [ForeignKey("ModifiedBy")]
    public User ModifiedByUser { get; set; }


}
