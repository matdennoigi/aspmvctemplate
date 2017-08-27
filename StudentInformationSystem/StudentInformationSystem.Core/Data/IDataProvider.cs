using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Data
{
    public interface IDataProvider
    {
        void InitConnectionFactory();

        void SetDatabaseInitializer();

        void InitDatabase();

        bool StoredProceduredSupported { get; }

        bool BackupSupported { get; }

        DbParameter GetParameter();

        int SupportedLengthOfBinaryHash();
    }
}
