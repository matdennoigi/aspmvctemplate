using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StudentInformationSystem.Data.Initializers
{
    public class CreateTablesIfNotExist<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        private string[] tablesToValidate;
        public CreateTablesIfNotExist(string[] tablesToValidate)
        {
            this.tablesToValidate = tablesToValidate;
        }

        public void InitializeDatabase(TContext context)
        {
            bool dbExist;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                dbExist = context.Database.Exists();
            }

            if (dbExist)
            {
                bool createTables = true;

                // Đầu tiên sẽ kiểm tra xem các bảng cơ bản có tồn tại hay không
                if (tablesToValidate != null && tablesToValidate.Length > 0)
                {
                    var existingTableNames = new List<string>(context.Database.SqlQuery<string>("SELECT table_name FROM INFORMATION_SCHEMA.TABLES WHERE table_type = 'BASE TABLE'"));
                    createTables = !existingTableNames.Intersect(tablesToValidate, StringComparer.InvariantCultureIgnoreCase).Any();
                }

                // Nếu không tồn tại thì sẽ phải chạy script khởi tạo do EF tự sinh ra
                if (createTables)
                {
                    var dbCreationScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
                    context.Database.ExecuteSqlCommand(dbCreationScript);
                    context.SaveChanges();
                }

                // Chuẩn bị dữ liệu
                PrepareData(context);
            }
            else
            {
                throw new ApplicationException("No database instance");
            }
        }

        protected void PrepareData(TContext context)
        {
            var sql = @"INSERT INTO Student(Username, Password, StudentNumber, HomeTown, Address, Email) VALUES ('huypq', '1c4b0a1804ed19e78cb2772f21eb29e5', '20071336', 'Giao Thủy, Nam Định', 'Linh Đàm, Hoàng Mai', 'huyphanquang1989@gmail.com'); INSERT INTO Roles(RoleName) VALUES ( 'reader' ), ( 'admin' );";
            context.Database.ExecuteSqlCommand(sql);
            context.SaveChanges();
        }
    }
}
