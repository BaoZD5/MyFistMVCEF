using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEF.ExEntity
{
    public class SysDepartment
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public String DepartmentDesc { get; set; }

        public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}
