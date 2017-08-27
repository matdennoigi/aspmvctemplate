using StudentInformationSystem.Core.Domain.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Data.Mapping.Membership
{
    public class RoleMap : AppEntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("Roles");
            this.HasKey(r => r.Id);
            this.Property(r => r.RoleName).IsRequired();
        }
    }
}
