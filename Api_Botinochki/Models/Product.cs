using System;
using System.Collections.Generic;

namespace Api_Botinochki.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductArticle { get; set; }

    public int? ProductNameId { get; set; }

    public string? Unit { get; set; }

    public decimal? Price { get; set; }

    public int? SupplierId { get; set; }

    public int? ManufacturerId { get; set; }

    public int? ProductСategoryId { get; set; }

    public int? CurrentDiscount { get; set; }

    public int? QuantityStock { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductName? ProductName { get; set; }

    public virtual ProductСategory? ProductСategory { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
