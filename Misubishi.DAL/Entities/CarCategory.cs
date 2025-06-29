﻿using System;
using System.Collections.Generic;

namespace Misubishi.DAL.Entities;

public partial class CarCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
