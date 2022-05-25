using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserRoleDal : IGenericDal<UserRole>
    {
        IList<UserRole> GetByUserNameAndPass(string userName, string pass);
        IList<UserRole> GetUserRoleById(long id);

    }
}
