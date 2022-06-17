using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IActivityService
    {
        void ActivityAdd(Activity activity);
        void ActivityDeleteById(long activityId, long deletedBy, DateTime deletedTime);
        void ActivityUpdate(Activity activity);
        void ChangeActivityConfirmation(long activityId, bool isConfirmed, long confirmedBy, DateTime confirmedTime);
        IList<Activity> GetList();
        IList<ActivityViewModel> GetListOrderByCreatedTime();
        IList<ActivityViewModel> GetListOrderByCreatedTimeAndByUserId(long userId);
        IList<Activity> GetConfirmedList();
        Activity GetById(long id);
        bool CheckEmptyKontenjan(long activityId);
    }
}
