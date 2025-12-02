using System;
using System.Collections.Generic;

namespace Api_Botinochki.Models;

public partial class Order
{
    public int OrderNumberId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public int? PvzId { get; set; }

    public int? UserId { get; set; }

    public int? Code { get; set; }

    public int? OrderStatusId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual Pvz? Pvz { get; set; }

    public virtual User? User { get; set; }
}
