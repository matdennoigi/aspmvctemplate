using StudentInformationSystem.Core;
using StudentInformationSystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Data
{
    public class EfRepository<T> : IRepository<T>
        where T: BaseEntity
    {
        #region Fields 

        private IDbContext context;
        private IDbSet<T> entities;

        #endregion

        #region Ctors

        public EfRepository(IDbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Entities.Add(entity);
            }

            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        protected IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                    entities = context.Set<T>();

                return entities;
            }
        }

        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        public IQueryable<T> TableNoTracking
        {
            get { return Entities.AsNoTracking(); }
        }


        #endregion
    }
}
