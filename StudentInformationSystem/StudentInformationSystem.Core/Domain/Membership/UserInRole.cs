using StudentInformationSystem.Core.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Domain.Membership
{
    public class UserInRole : BaseEntity
    {
        public int StudentId { set; get; }

        public int RoleId { set; get; }

        public DateTime GrantOnUtc { set; get; }

        public virtual Student Student { set; get; }
        
        public virtual Role Role { set; get; }
    }
}
