using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Grup { get; set; }
        //[InverseProperty("InvitedUser")]
        //public virtual ICollection<ActivityInvite> InvitedUser { get; set; }
        //[InverseProperty("CreatedUser")]
        //public virtual ICollection<ActivityInvite> CreatedUser { get; set; }
        //[InverseProperty("ConfirmedUser")]
        //public virtual ICollection<ActivityInvite> ConfirmedUser { get; set; }
        //[InverseProperty("DeletedUser")]
        //public virtual ICollection<ActivityInvite> DeletedUser { get; set; }
    }
}
