using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XEngine.Web.Models
{
    public interface IWeapon
    {
        string Hit(string target);
    }
}
