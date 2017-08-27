using StudentInformationSystem.Core.Domain.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Domain.Students
{
    public class Student : BaseEntity
    {
        public string Username { set; get; }

        public string Password { set; get; }

        public string StudentNumber { set; get; }

        /// <summary>
        /// Quê quán
        /// </summary>
        public string HomeTown { set; get; }

        /// <summary>
        /// Địa chỉ liên hệ
        /// </summary>
        public string Address { set; get; }

        public string Email { set; get; }

        public virtual ICollection<UserInRole> UserInRoles { set; get; }
    }
}
