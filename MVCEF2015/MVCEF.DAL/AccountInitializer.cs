using MVCEF.ExEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEF.DAL
{
    public class AccountInitializer : DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var sysUsers = new List<SysUser> {
                new SysUser{ UserName = "Java",Email="Java@qq.com",CreateDate=DateTime.Now, Password = "123"},
                new SysUser{ UserName = "Net",Email="Net@qq.com",CreateDate=DateTime.Now, Password = "123"}
            };
            sysUsers.ForEach(x => context.SysUsers.Add(x));
            context.SaveChanges();

            var sysRoles = new List<SysRole>
            {
                new SysRole{ RoleName = "Administrator",RoleDesc = "Administrator have full"},
                new SysRole { RoleName ="General",RoleDesc ="Aeneral have Users"}
            };
            sysRoles.ForEach(x => context.SysRoles.Add(x));
            context.SaveChanges();
        }
    }
}
