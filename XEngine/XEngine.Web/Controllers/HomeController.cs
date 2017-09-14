using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XEngine.Web.DAL;
using XEngine.Web.Models;
using XEngine.Web.Utility;

namespace XEngine.Web.Controllers
{

    public class HomeController : Controller
    {
        private XEngineContext db = new XEngineContext();

        
        private IWeapon weapon;

        public HomeController(IWeapon weaponParam)
        {
            weapon = weaponParam;
        }

        public ActionResult Battle()
        {

       
            //var warrior1 = new Samurai(new Sword());

            ////1. 创建一个Ninject的内核实例
            //IKernel ninjectKernel = new StandardKernel();
            ////2. 配置Ninject内核,指明接口需绑定的类
            //ninjectKernel.Bind<IWeapon>().To<Sword>();
            ////3. 根据上一步的配置创建一个对象
            //var weapon=ninjectKernel.Get<IWeapon>();

            var warrior1 = new Samurai(weapon);

            ViewBag.Res = warrior1.Attack("the evildoers");
            return View();
        }

        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}