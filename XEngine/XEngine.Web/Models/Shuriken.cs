using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XEngine.Web.Models
{
    public class Shuriken:IWeapon
    {
        public string Hit(string target)
        {
            return string.Format("Pierced {0}'s armor", target);
        }
    }
}