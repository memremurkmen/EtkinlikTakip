using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRoleRepository : GenericRepository<UserRole>, IUserRoleDal
    {
        Context c = new Context();

        public IList<UserRole> GetUserRoleById(long id)
        {
            var userRole = (from ur in c.UserRole
                            join u in c.User
                            on ur.UserId equals u.Id
                            join r in c.Role
                            on ur.RoleId equals r.Id
                            where ur.User.Id == id
                            select new UserRole
                            {
                                User = u,
                                Role = r,
                                Id = ur.Id
                            }).ToList();
            return userRole;
        }

        public IList<UserRole> GetByUserNameAndPass(string userName, string pass)
        {
            var userRole = (from ur in c.UserRole
                            join u in c.User
                            on ur.UserId equals u.Id
                            join r in c.Role
                            on ur.RoleId equals r.Id
                            where ur.User.UserName == userName && ur.User.Password == pass
                            select new UserRole
                            {
                                User = u,
                                Role = r,
                                Id = ur.Id
                            }).ToList();
            return userRole;
        }
    }
}
