using System;
using System.Collections.Generic;

namespace Api_Botinochki.Models;

public partial class ProductСategory
{
    public int ProductСategoryId { get; set; }

    public string? ProductСategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
