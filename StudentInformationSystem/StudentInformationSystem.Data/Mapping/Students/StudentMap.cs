using StudentInformationSystem.Core.Domain.Membership;
using StudentInformationSystem.Core.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Data.Mapping.Students
{
    public class StudentMap : AppEntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            this.ToTable("Student");
            this.HasKey(s => s.Id);
            this.Property(s => s.Username).HasMaxLength(32);
            this.Property(s => s.Password).HasMaxLength(32);
            this.Property(s => s.StudentNumber).HasMaxLength(16);
            this.Property(s => s.Email).HasMaxLength(1000);
        }
    }
}
