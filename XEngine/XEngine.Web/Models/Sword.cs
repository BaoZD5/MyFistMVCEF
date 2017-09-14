using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XEngine.Web.Models
{
    public class Sword:IWeapon
    {
        public string Hit(string target)
        {
            return string.Format("Chopped {0} clean in half", target);
        }
    }
}