using MVCEF.ExEntity;
using MVCEF.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;

namespace MVCEF2015.Controllers
{
    public class AccountController : Controller
    {
        private ISysUserBLL sysUserBLL = MVCEF.BLLContainer.Container.Resolve<ISysUserBLL>();

        // GET: Account
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (!string.IsNullOrEmpty(searchString))
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var users = sysUserBLL.GetAllUsers().Include(x => x.SysDeparment);

            //users = sysUserBLL.GetAllUsers().Include(x => x.SysDeparment).Include(x => x.SysUserRole).Where(x=>x.SysDeparment.DepartmentName.Contains("学习"));

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(x => x.UserName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(x => x.UserName);
                    break;
                default:
                    users = users.OrderBy(x => x.UserName);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (pageIndex ?? 1);

            return View(users.ToPagedList(pageNumber, pageSize));
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
            if (ModelState.IsValid)
            {
                sysUser.CreateDate = DateTime.Now;
                sysUserBLL.Add(sysUser);
                return RedirectToAction("Index");
            }
            return View();
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
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SysUser sysUser = sysUserBLL.GetAllUsers().FirstOrDefault(x => x.ID == id);
            sysUserBLL.Delete(sysUser);
            return RedirectToAction("Index");
        }
        #endregion
    }
}