using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public User GetById(long id)
        {
            return _userDal.GetByID(id);
        }
        public IList<User> GetList()
        {
            return _userDal.GetListAll();
        }
        public void UserAdd(User user)
        {
            _userDal.Insert(user);
        }
        public void UserDelete(User user)
        {
            if (user.Id != 0)
            {
                _userDal.Delete(user);
            }
        }
        public void UserUpdate(User user)
        {
            _userDal.Update(user);
        }
    }
}
