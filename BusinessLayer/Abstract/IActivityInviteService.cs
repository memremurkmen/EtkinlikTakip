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
        void ActivityInviteAdd(ActivityInvite activityInvite);
        void ActivityInviteDelete(ActivityInvite activityInvite);
        void ActivityInviteUpdate(ActivityInvite activityInvite);
        IList<ActivityInvite> GetList();
        ActivityInvite GetById(Guid id);
    }
}
