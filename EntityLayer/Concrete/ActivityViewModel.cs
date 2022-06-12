using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ActivityViewModel
    {
        public long ActivityID { get; set; }
        public Activity Activity { get; set; }
        public ActivityInvite ActivityInvite { get; set; }
    }
}
