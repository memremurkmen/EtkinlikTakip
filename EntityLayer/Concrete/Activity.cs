using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Activity : ISchedulerEvent
    {
        [Key]
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
        public string Grup { get; set; }
        public int MaksKontenjan { get; set; }

        public bool IsConfirmed { get; set; }
        [ForeignKey("ConfirmedUser")]
        public long? ConfirmedBy { get; set; }
        public virtual User ConfirmedUser { get; set; }
        public DateTime? ConfirmedTime { get; set; }

        [ForeignKey("CreatedUser")]
        public long CreatedBy { get; set; }
        public virtual User CreatedUser { get; set; }
        public DateTime CreatedTime { get; set; }

        [ForeignKey("UpdatedUser")]
        public long? UpdatedBy { get; set; }
        public virtual User UpdatedUser { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public bool IsDeleted { get; set; }
        [ForeignKey("DeletedUser")]
        public long? DeletedBy { get; set; }
        public virtual User DeletedUser { get; set; }
        public DateTime? DeletedTime { get; set; }

        //[InverseProperty("Activity")]
        public virtual ICollection<ActivityInvite> Invitees { get; set; }
    }
}
