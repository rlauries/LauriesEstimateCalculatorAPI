using LauriesEC.Fences.Repositories.DatabaseContext;
using Security.Interfaces;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Security.Services
{
    public class Login : ILogin
    {
        bool isLoggedIn = false;
        LauriesContext _lauriesContext;
        public Login()
        {
            _lauriesContext = new LauriesContext();
        }
        public bool IsLoggedIn(string userName, string password)
        {
            LoginModel loginFromDataBase = _lauriesContext.GetPasswordAndSaltByUserName(userName);
            byte[] saltBytes = loginFromDataBase.Salty;
            bool isLoggedIn = password.VerifyPassword(saltBytes, loginFromDataBase.HashPassword);
            return isLoggedIn;
        }
        
    }
}
