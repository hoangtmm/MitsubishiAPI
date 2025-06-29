using System;
using System.Collections.Generic;

namespace Misubishi.DAL.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }
}
