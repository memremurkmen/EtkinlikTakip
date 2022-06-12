using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IActivityInviteService
    {
        void AddActivityInvite(ActivityInvite activityInvite);
        void DeleteActivityInviteById(Guid activityInviteId, long deletedBy, DateTime deletedTime);
        void UpdateActivityInvite(ActivityInvite activityInvite);
        IList<ActivityInvite> GetList();
        ActivityInvite GetById(Guid id);
        ActivityInvite CheckActivityInvite(long activityId, long invitedUserId);
        IList<ActivityInvite> GetInvitesByActivityId(long activityId);
    }
}
