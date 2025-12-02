using System;
using System.Collections.Generic;

namespace Api_Botinochki.Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string? UserRole1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
