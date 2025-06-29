using System;
using System.Collections.Generic;

namespace Misubishi.DAL.Entities;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Content { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? PublishedAt { get; set; }
}
