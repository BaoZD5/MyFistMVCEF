using MVCEF.IBLL;
using MVCEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEF2015.Controllers
{
    public class UserController : Controller
    {
        private IUserService StaffService = MVCEF.BLLContainer.Container.Resolve<IUserService>();
        // GET: Home
        public ActionResult UserIndex()
        {
            List<User> list = StaffService.GetModels(p => true).ToList();
            return View(list);
        }
        public ActionResult Add(User staff)
        {
            if (StaffService.Add(staff))
            {
                return Redirect("UserIndex");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Update(User staff)
        {
            if (StaffService.Update(staff))
            {
                return Redirect("UserIndex");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Delete(int Id)
        {
            var staff = StaffService.GetModels(p => p.ID == Id).FirstOrDefault();
            if (StaffService.Delete(staff))
            {
                return Redirect("UserIndex");
            }
            else
            {
                return Content("no");
            }
        }
    }
}