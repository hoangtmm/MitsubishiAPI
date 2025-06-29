using System;
using System.Collections.Generic;

namespace Misubishi.DAL.Entities;

public partial class QuickQuote
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? CarModel { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedAt { get; set; }
}
