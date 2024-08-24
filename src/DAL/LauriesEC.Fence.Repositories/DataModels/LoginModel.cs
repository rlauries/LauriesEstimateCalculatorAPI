using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Models
{
    public class LoginModel
    {
        public string HashPassword { get; set; }
        public byte[] Salty { get; set; }
        public string? ResultDescription { get; set; }
    }
}
