using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        IUserRoleDal _userRoleDal;
        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }
        public UserRole GetById(long id)
        {
            return _userRoleDal.GetByID(id);
        }

        public IList<UserRole> GetUserRoleById(long id)
        {
            return _userRoleDal.GetUserRoleById(id);
        }

        public IList<UserRole> GetByUserNameAndPass(string userName, string pass)
        {
            return _userRoleDal.GetByUserNameAndPass(userName,pass);
        }

        public IList<UserRole> GetList()
        {
            return _userRoleDal.GetListAll();
        }

        

        public void UserRoleAdd(UserRole userRole)
        {
            _userRoleDal.Insert(userRole);
        }

        public void UserRoleDelete(UserRole userRole)
        {
            if (userRole.Id != 0)
            {
                _userRoleDal.Delete(userRole);
            }
        }

        public void UserRoleUpdate(UserRole userRole)
        {
            _userRoleDal.Update(userRole);
        }
    }
}

