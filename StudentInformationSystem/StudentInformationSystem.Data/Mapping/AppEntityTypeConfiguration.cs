using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Data.Mapping
{
    public class AppEntityTypeConfiguration<T> : EntityTypeConfiguration<T>
        where T : class
    {
        protected AppEntityTypeConfiguration()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {
        }
    }
}
