using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IActivityInviteDal : IGenericDal<ActivityInvite>
    {
        void DeleteActivityInviteById(Guid activityInviteId, long deletedBy, DateTime deletedTime);
        void ChangeInviteConfirmation(Guid activityInviteId, bool isConfirmed, long confirmedBy, DateTime confirmedTime);
        ActivityInvite CheckActivityInvite(long activityId, long invitedUserId);
        IList<ActivityInvite> GetInvitees(long activityId);
        IList<ActivityInvite> GetInvitees(long activityId, bool isConfirmed);
    }
}
