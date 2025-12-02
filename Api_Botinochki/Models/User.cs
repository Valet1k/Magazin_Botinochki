using System;
using System.Collections.Generic;

namespace Api_Botinochki.Models;

public partial class User
{
    public int UserId { get; set; }

    public int? UserRoleId { get; set; }

    public string? Fio { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

}

public partial class CreateUser
{
    public int? UserRoleId { get; set; }

    public string? Fio { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}

public partial class LoginUser
{
    public string? Login { get; set; }
    public string? Password { get; set; }
}
