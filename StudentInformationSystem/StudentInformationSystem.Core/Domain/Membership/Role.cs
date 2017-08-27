using StudentInformationSystem.Core.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Domain.Membership
{
    public class Role : BaseEntity
    {
        public string RoleName { set; get; }

        public virtual ICollection<UserInRole> UserInRoles { set; get; }
    }
}
