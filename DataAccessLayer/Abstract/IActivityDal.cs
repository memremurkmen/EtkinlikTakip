using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IActivityDal : IGenericDal<Activity>
    {
        IList<ActivityViewModel> GetListOrderByCreatedTime();
        IList<Activity> GetConfirmedList();
        void ChangeActivityConfirmation(long activityId, bool isConfirmed, long updatedBy, DateTime updatedTime);
        void DeleteActivityById(long activityId, long deletedBy, DateTime deletedTime);
        bool CheckEmptyKontenjan(long activityId);
    }
}
