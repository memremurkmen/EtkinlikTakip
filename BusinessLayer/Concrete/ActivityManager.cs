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
    public class ActivityManager : IActivityService
    {
        IActivityDal _activityDal;
        public ActivityManager(IActivityDal activityDal)
        {
            _activityDal = activityDal;
        }
        public Activity GetById(long id)
        {
            return _activityDal.GetByID(id);
        }

        public IList<Activity> GetList()
        {
            return _activityDal.GetListAll();
        }

        public void ActivityAdd(Activity activity)
        {
            _activityDal.Insert(activity);
        }


        public void ActivityDeleteById(long activityId, long deletedBy, DateTime deletedTime)
        {
            if (activityId != 0)
            {
                _activityDal.DeleteActivityById(activityId, deletedBy, deletedTime);
            }
        }

        public void ActivityUpdate(Activity activity)
        {
            _activityDal.Update(activity);
        }

        public bool CheckEmptyKontenjan(long activityId)
        {
            return _activityDal.CheckEmptyKontenjan(activityId);
        }

        public IList<Activity> GetConfirmedList()
        {
            return _activityDal.GetConfirmedList();
        }

        public IList<ActivityViewModel> GetListOrderByCreatedTime()
        {
            return _activityDal.GetListOrderByCreatedTime();
        }

        public void ChangeActivityConfirmation(long activityId, bool isConfirmed, long updatedBy, DateTime updatedTime)
        {
            _activityDal.ChangeActivityConfirmation(activityId, isConfirmed, updatedBy, updatedTime);
        }


    }
}
