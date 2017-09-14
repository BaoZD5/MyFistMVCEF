using System;
using System.Collections.Generic;
using System.Text;

namespace MVCEF.ExEntity
{
    public class SysUserRole
    {
        public int ID { get; set; }
        public int SysUserID { get; set; }
        public int SysRoleID { get; set; }
        public virtual SysUser SysUser { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}
