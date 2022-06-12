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

        public void AddActivityInvite(ActivityInvite activityInvite)
        {
            _activityInviteDal.Insert(activityInvite);
        }

        public void DeleteActivityInviteById(Guid activityInviteId, long deletedBy, DateTime deletedTime)
        {
            if (activityInviteId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                _activityInviteDal.DeleteActivityInviteById(activityInviteId,deletedBy,deletedTime);
            }
        }

        public void UpdateActivityInvite(ActivityInvite activityInvite)
        {
            _activityInviteDal.Update(activityInvite);
        }

        public ActivityInvite CheckActivityInvite(long activityId, long invitedUserId)
        {
            return _activityInviteDal.CheckActivityInvite(activityId, invitedUserId);
        }

        public IList<ActivityInvite> GetInvitesByActivityId(long activityId)
        {
            return _activityInviteDal.GetInvitesByActivityId(activityId);
        }
    }
}
