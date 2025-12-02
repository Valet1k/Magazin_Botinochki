using System;
using System.Collections.Generic;

namespace Api_Botinochki.Models;

public partial class ProductName
{
    public int ProductNameId { get; set; }

    public string? ProductName1 { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
