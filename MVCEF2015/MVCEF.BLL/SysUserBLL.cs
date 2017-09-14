using MVCEF.ExEntity;
using MVCEF.IBLL;
using MVCEF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEF.BLL
{
    public class SysUserBLL : BaseService<SysUser>, ISysUserBLL
    {
        private ISysUserDAL sysUserDAL = DALContainer.Container.Resolve<ISysUserDAL>();
        public override void SetDal()
        {
            Dal = sysUserDAL;
        }
        public IQueryable<SysUser> GetAllUser()
        {
            return sysUserDAL.GetList();
        }
    }
}
