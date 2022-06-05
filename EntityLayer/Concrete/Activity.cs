using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Activity : ISchedulerEvent
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }

        public string Image { get; set; }
        public string Location { get; set; }
        public int MaksKontenjan { get; set; }
        public bool isConfirmed { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public long UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        public long DeleteBy { get; set; }
        public DateTime DeleteTime { get; set; }

        public virtual ICollection<ActivityInvite> Invitee { get; set; }
    }
}
