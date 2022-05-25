using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserRoleService
    {
        void UserRoleAdd(UserRole userRole);
        void UserRoleDelete(UserRole userRole);
        void UserRoleUpdate(UserRole userRole);
        IList<UserRole> GetList();
        UserRole GetById(long id);
        IList<UserRole> GetUserRoleById(long id);
        IList<UserRole> GetByUserNameAndPass(string userName, string pass);
    }
}
