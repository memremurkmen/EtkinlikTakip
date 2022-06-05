using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfActivityInviteRepository : GenericRepository<ActivityInvite>, IActivityInviteDal
    {
        Context c = new Context();

        public void DeleteActivityInvite(ActivityInvite activityInvite)
        {
            var ai = c.Activity.Find(activityInvite.Id);
            ai.IsDeleted = true;
            c.SaveChanges();
        }
    }
}
