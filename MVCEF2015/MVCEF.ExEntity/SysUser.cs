using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCEF.ExEntity
{
    public class SysUser
    {
        public int ID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public virtual ICollection<SysUserRole> SysUserRole { get; set; }
    }
}
