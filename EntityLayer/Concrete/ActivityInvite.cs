using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ActivityInvite
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("InvitedUser")]
        public long InvitedUserId { get; set; }
        public virtual User InvitedUser { get; set; }

        [ForeignKey("AIActivity")]
        public long ActivityId { get; set; }
        public virtual Activity AIActivity { get; set; }

        [ForeignKey("AICreatedUser")]
        public long CreatedBy { get; set; }
        public virtual User AICreatedUser { get; set; }
        public DateTime CreatedTime { get; set; }

        public bool IsConfirmed { get; set; }
        [ForeignKey("AIConfirmedUser")]
        public long? ConfirmedBy { get; set; }
        public virtual User AIConfirmedUser { get; set; }
        public DateTime? ConfirmedTime { get; set; }

        public bool IsDeleted { get; set; }
        [ForeignKey("AIDeletedUser")]
        public long? DeletedBy { get; set; }
        public virtual User AIDeletedUser { get; set; }
        public DateTime? DeletedTime { get; set; }


    }
}
