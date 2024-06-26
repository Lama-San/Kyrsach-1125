﻿using System;
using System.Collections.Generic;

namespace Курсач_сайко_1125;

public partial class Role
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
