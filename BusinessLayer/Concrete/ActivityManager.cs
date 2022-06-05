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

        public void ActivityDelete(Activity activity)
        {
            if (activity.ID != 0)
            {
                _activityDal.DeleteActivity(activity);
            }
        }

        public void ActivityUpdate(Activity activity)
        {
            _activityDal.Update(activity);
        }
    }
}
