using MVCEF.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEF2015.Controllers
{
    public class AccountController : Controller
    {
        private ISysUserBLL sysUserBLL = MVCEF.BLLContainer.Container.Resolve<ISysUserBLL>();

        // GET: Account
        public ActionResult Index()
        {
            return View(sysUserBLL.GetAllUsers());
        }
        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前。。。";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];

            var userInfo = "";

            ViewBag.LoginState = email + "登录后。。。";
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}