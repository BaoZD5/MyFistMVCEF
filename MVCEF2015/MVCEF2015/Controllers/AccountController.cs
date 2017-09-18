using MVCEF.ExEntity;
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

            var userInfo = sysUserBLL.GetAllUsers().FirstOrDefault(x => x.Email == email && x.Password == password);
            if (userInfo != null)
                ViewBag.LoginState = email + "登录后。。。";
            else
                ViewBag.LoginState = "无此用户！";
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            SysUser sysUser = sysUserBLL.GetAllUsers().FirstOrDefault(x => x.ID == id);
            return View(sysUser);
        }
        #region 新增
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SysUser sysUser)
        {
            sysUserBLL.Add(sysUser);
            return RedirectToAction("Index");
        }
        #endregion
        #region 修改
        public ActionResult Edit(int id)
        {
            SysUser user = sysUserBLL.GetAllUsers().FirstOrDefault(x => x.ID == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(SysUser sysUser)
        {
            sysUserBLL.Update(sysUser);
            return RedirectToAction("Index");
        }
        #endregion
        #region 删除
        public ActionResult Delete(int id)
        {
            SysUser sysUser = sysUserBLL.GetAllUsers().FirstOrDefault(x => x.ID == id);
            return View(sysUser);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SysUser sysUser = sysUserBLL.GetAllUsers().FirstOrDefault(x => x.ID == id);
            sysUserBLL.Delete(sysUser);
            return View(RedirectToAction("Index"));
        } 
        #endregion
    }
}