using LauriesEC.Fence.Models;
using LauriesEC.Fences.Repositories.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Interfaces;
using Security.Models;
using Security.Services;
using System.Text;

namespace LauriesEC.Fence.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        LauriesContext _lauriesContext;
        ILogin _login;
        //Security.Login
        public UserController(ILogin login)
        {
            _lauriesContext = new LauriesContext();
            _login = login;
        }

        [HttpPost("SignUp")]
        public ActionResult<UserModel> SignUp(SignUpModelFromBody signUpModel)
        {
            UserModel model = new UserModel();
            byte[] salty = EncryptPassword.GenerateSalt(); 
            model.Salty = salty;
             

            model.HashPassword = signUpModel.Password.HashPassword(salty);
            model.UserName = signUpModel.UserName;
            model.RoleId = 1;
            model.CustomerId = signUpModel.CustomerId;
            var newModel = _lauriesContext.SignUp(model);

            return Ok(newModel);
        }

        [HttpGet("GetPasswordAndSaltByUserName/{userName}")]
        public ActionResult<LoginModel> GetPasswordAndSaltByUserName(string userName)
        {
            var pass = _lauriesContext.GetPasswordAndSaltByUserName(userName);
            return Ok(pass);
        }

        [HttpPost("Login")]
        public ActionResult<bool> Login(LoginFromBody model) 
        {
            bool isLogged = _login.IsLoggedIn(model.UserName, model.Password);
            return Ok(isLogged);
        }



    }
}
