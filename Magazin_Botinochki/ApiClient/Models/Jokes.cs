using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_Botinochki.ApiClient.Models
{
    internal class Jokes
    {
        public int id {  get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
    }
}
