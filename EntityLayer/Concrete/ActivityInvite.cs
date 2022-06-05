using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ActivityInvite
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public long EtkinlikId { get; set; }
        public bool IsConfirmed { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public long ConfirmBy { get; set; }
        public DateTime ConfirmTime { get; set; }
        public bool IsDeleted { get; set; }
        public long DeleteBy { get; set; }
        public DateTime DeleteTime { get; set; }

        public virtual User User { get; set; }
        public virtual Activity Activity { get; set; }

    }
}
