using LoginTask.DBContext;
using LoginTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LoginTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginTaskDbContext _loginTaskDbContext;

        public HomeController(ILogger<HomeController> logger, LoginTaskDbContext loginTaskDbContext)
        {
            _logger = logger;
            this._loginTaskDbContext = loginTaskDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserLoginModel _userLoginModel = new UserLoginModel();
            return View(_userLoginModel);
        }

       /* public async Task<IActionResult> UserInform()
        {
            return View(await _loginTaskDbContext.UserInfos.ToListAsync());
        }
        */
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
            LoginTaskDbContext loginTaskDbContext = new LoginTaskDbContext();
            var userstatus = loginTaskDbContext.UserInfos.Where(m => m.UserName == _userLoginModel.Username).FirstOrDefault();
            if (userstatus == null)
            {
                ViewBag.ErrorMessage = "Đã xảy ra lỗi!";
            };
            
            var status = loginTaskDbContext.UserInfos.Where(m => m.UserName == _userLoginModel.Username && m.Passwordhash == _userLoginModel.Password).FirstOrDefault();
            if (status == null) 
            {
                ViewBag.LoginStatus = 0;
            }        
            else
            {
                
                return RedirectToAction("Index","User");
            }
                
                return View(_userLoginModel);
        }

        public IActionResult SuccessPage()
        {
            return View();  
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