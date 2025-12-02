using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_Botinochki.ApiClient.Models
{
    public class UserModels
    {
        public int UserId { get; set; }

        public int? UserRoleId { get; set; }

        public string Fio { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }

    public partial class LoginUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
