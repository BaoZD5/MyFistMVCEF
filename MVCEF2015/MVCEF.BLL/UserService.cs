using MVCEF.IBLL;
using MVCEF.IDAL;
using MVCEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEF.BLL
{

    public partial class UserService : BaseService<User>, IUserService
    {
        private IUserDAL StaffDAL = DALContainer.Container.Resolve<IUserDAL>();
        public override void SetDal()
        {
            Dal = StaffDAL;
        }
    }
}
