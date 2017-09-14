using System;
using System.Collections.Generic;
using System.Text;

namespace MVCEF.ExEntity
{
    public class SysUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public virtual ICollection<SysUserRole> SysUserRole { get; set; }
    }
}
