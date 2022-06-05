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
        void ActivityDelete(Activity activity);
        void ActivityUpdate(Activity activity);
        IList<Activity> GetList();
        Activity GetById(long id);
    }
}
