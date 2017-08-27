using StudentInformationSystem.Core.Domain.Membership;
using StudentInformationSystem.Core.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Data.Mapping.Membership
{
    public class UserInRoleMap : AppEntityTypeConfiguration<UserInRole>
    {
        public UserInRoleMap()
        {
            this.ToTable("UsersInRoles");

            this.HasRequired<Student>(uir => uir.Student)
                .WithMany(s => s.UserInRoles)
                .HasForeignKey(uir => uir.StudentId);

            this.HasRequired<Role>(uir => uir.Role)
                .WithMany(r => r.UserInRoles)
                .HasForeignKey(uir => uir.RoleId);
        }
    }
}
