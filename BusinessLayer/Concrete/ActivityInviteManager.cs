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
    public class ActivityInviteManager : IActivityInviteService
    {
        IActivityInviteDal _activityInviteDal;
        public ActivityInviteManager(IActivityInviteDal activityInviteDal)
        {
            _activityInviteDal = activityInviteDal;
        }
        public ActivityInvite GetById(Guid id)
        {
            return _activityInviteDal.GetByID(id);
        }

        public IList<ActivityInvite> GetList()
        {
            return _activityInviteDal.GetListAll();
        }

        public void ActivityInviteAdd(ActivityInvite activityInvite)
        {
            _activityInviteDal.Insert(activityInvite);
        }

        public void ActivityInviteDelete(ActivityInvite activityInvite)
        {
            if (activityInvite.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                _activityInviteDal.DeleteActivityInvite(activityInvite);
            }
        }

        public void ActivityInviteUpdate(ActivityInvite activityInvite)
        {
            _activityInviteDal.Update(activityInvite);
        }

    }
}
