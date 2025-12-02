using System;
using System.Collections.Generic;

namespace Api_Botinochki.Models;

public partial class Pvz
{
    public int PvzId { get; set; }

    public string? PvzName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
