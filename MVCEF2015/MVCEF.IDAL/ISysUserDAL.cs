﻿using MVCEF.ExEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEF.IDAL
{
    public interface ISysUserDAL : IBaseDAL<SysUser>
    {
        IQueryable<SysUser> GetList();
    }
}