using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfActivityRepository : GenericRepository<Activity>, IActivityDal
    {
        Context c = new Context();

        public void DeleteActivity(Activity activity)
        {
            var a = c.Activity.Find(activity.ID);
            a.IsDeleted = true;
            c.SaveChanges();
        }

    }
}
