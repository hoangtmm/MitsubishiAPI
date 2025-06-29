using System;
using System.Collections.Generic;

namespace Misubishi.DAL.Entities;

public partial class TestDrife
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? CarModel { get; set; }

    public DateTime? PreferredDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
