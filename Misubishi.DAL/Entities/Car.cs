using System;
using System.Collections.Generic;

namespace Misubishi.DAL.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public virtual CarCategory? Category { get; set; }
}
