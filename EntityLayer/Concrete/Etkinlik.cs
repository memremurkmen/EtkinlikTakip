using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Etkinlik : ISchedulerEvent
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteTime { get; set; }

    }
}
