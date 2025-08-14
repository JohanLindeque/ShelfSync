using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShelfSync.Shared.Entities;

public class StorageBin
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }


    public required int CategoryID { get; set; }
    [ForeignKey("CategoryID")]
    public Category Category { get; set; }


    public required DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    [ForeignKey("CreatedBy")]
    public IdentityUser CreatedByUser { get; set; }



    public DateTime ModifiedAt { get; set; }


}
