using MVCEF.ExEntity;
using MVCEF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEF.DAL
{
    public class SysUserDAL : SysBaseDAL<SysUser>, ISysUserDAL
    {
        public IQueryable<SysUser> GetList()
        {
            //db.SysUsers.Where(x=>x.Email == "");
            return db.SysUsers;
        }
    }
}
