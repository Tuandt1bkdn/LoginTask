using LoginTask.DBContext;
using LoginTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace LoginTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginTaskDbContext _loginTaskDbContext;
        /*private readonly DataContext _dataContext;*/

        public HomeController(ILogger<HomeController> logger, LoginTaskDbContext loginTaskDbContext)
        {
            _logger = logger;
            this._loginTaskDbContext = loginTaskDbContext;
            /*this._dataContext = dataContext;*/
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
                if (password == "")
                {
                    return "";
                }
            else
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i< hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserLoginModel _userLoginModel = new UserLoginModel();
            return View(_userLoginModel);
        }

        public IActionResult UserInfo()
        {
            UserModel userModel = new UserModel();
            userModel.UserList = new List<UserInfoModel>();
            var userinfo = _loginTaskDbContext.UserInfos.ToList();
            /* foreach(var item in data)
            {
                userModel.UserList.Add(new UserInfoModel
                {
                    UserId= item.UserId,
                    Name= item.Name,
                    Birthday= item.Birthday,
                    Location= item.Location,
                    Email= item.Email
                });   
            } */
            return View(userinfo);
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()

        {
            var user = _loginTaskDbContext.UserInfos.ToList();
            return View(user);
        }


        [HttpPost]
        public IActionResult Index(UserLoginModel _userLoginModel)
        {
            //DataContext dataContext = new DataContext();
            LoginTaskDbContext loginTaskDbContext = new LoginTaskDbContext();

            if (_userLoginModel.Username == null && _userLoginModel.Password == null)
            {
                ViewBag.ErrorMessage = "You have not entered Username and Password !!!";
            }
            if (_userLoginModel.Username != null)
            {
                var userstatus = loginTaskDbContext.UserInfos.Where(m => m.UserName == _userLoginModel.Username).FirstOrDefault();
                if (userstatus == null)
                {
                    ViewBag.ErrorMessage = "Invalid Username !!!";
                };
            }
            if (_userLoginModel.Password == null) { ViewBag.LoginStatus = 0; }

            if (_userLoginModel.Username != null && _userLoginModel.Password != null)
            {
                var status = loginTaskDbContext.UserInfos.Where(m => m.UserName == _userLoginModel.Username && m.PasswordHash.Equals(HashPassword(_userLoginModel.Password))).FirstOrDefault();
                if (status == null)
                {
                    ViewBag.LoginStatus = 0;
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
            return View(_userLoginModel);
           
        }
    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//comment 
/*public IActionResult SuccessPage()
        {
            return View();  
        }*/
// var userstatus = loginTaskDbContext.UserInfos.Where(m => m.UserName == _userLoginModel.Username).FirstOrDefault();
/*if (userstatus == null)
{
    ViewBag.ErrorMessage = "Invalid Username!";
};*/
//var passwordunhash = _userLoginModel.Password;
/*if (_userLoginModel.Password == null) { ViewBag.LoginStatus = 0; }
else {
    var status = loginTaskDbContext.UserInfos.Where(m => m.UserName == _userLoginModel.Username && m.PasswordHash.Equals(HashPassword(_userLoginModel.Password))).FirstOrDefault();
    if (status == null)
    {
        ViewBag.LoginStatus = 0;
    }
    else
    {

        return RedirectToAction("Index", "User");
    }

}*/
