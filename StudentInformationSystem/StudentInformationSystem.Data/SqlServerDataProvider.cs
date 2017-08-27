using StudentInformationSystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.SqlClient;
using StudentInformationSystem.Data.Initializers;

namespace StudentInformationSystem.Data
{
    public class SqlServerDataProvider : IDataProvider
    {
        #region Methods

        public void InitConnectionFactory()
        {
            var connectionFactory = new SqlConnectionFactory();
            #pragma warning disable 0618
            Database.DefaultConnectionFactory = connectionFactory;
        }

        public void InitDatabase()
        {
            InitConnectionFactory();
            SetDatabaseInitializer();
        }

        public void SetDatabaseInitializer()
        {
            // Danh sách các bảng cần phải có trong DB
            var tablesToValidate = new string[] { "Student", "Role" };

            var initializer = new CreateTablesIfNotExist<AppObjectContext>(tablesToValidate);
            Database.SetInitializer(initializer);
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppObjectContext>());
        }

        public DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        public int SupportedLengthOfBinaryHash()
        {
            return 8000;
        }

        #endregion

        #region Properties

        public bool StoredProceduredSupported
        {
            get { return true; }
        }

        public bool BackupSupported
        {
            get { return true; }
        }

        #endregion
    }
}
