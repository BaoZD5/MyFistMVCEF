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
        [StringLength(50, MinimumLength = 1, ErrorMessage = "名字不能超过50个字")]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Sex { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        public virtual ICollection<SysUserRole> SysUserRole { get; set; }

        public int? SysDepartmentID { get; set; }
    }
}
