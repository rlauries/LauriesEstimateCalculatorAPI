using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Interfaces
{
    public interface ILogin
    {
        bool IsLoggedIn(string userName, string password);
    }
}
