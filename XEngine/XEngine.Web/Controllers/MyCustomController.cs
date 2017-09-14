using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using XEngine.Web.Utility;

namespace XEngine.Web.Controllers
{
    public class MyCustomController:IController
    {
        public void Execute(RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Write("Hello world.");
        }
    }
}