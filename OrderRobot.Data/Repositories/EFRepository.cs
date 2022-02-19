using Microsoft.EntityFrameworkCore;
using OrderRobot.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderRobot.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly MainContext _mainContext;

        private readonly DbSet<T> _dbSet;

        public EFRepository(MainContext mainContext)
        {
            if (mainContext == null)
                throw new ArgumentNullException("mainContext can not be null.");

            _mainContext = mainContext;
            try
            {
                _dbSet = mainContext.Set<T>();
            }
            catch (Exception ex)
            {

            }
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public void Add(T entity)
        {
            _mainContext.Entry(entity).State = EntityState.Added;
            // _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _mainContext.Entry(entity).State = EntityState.Deleted;
            // _dbSet.Delete(entity);
        }

        public void Update(T entity)
        {
            _mainContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this._dbSet;
            }
        }

    }
}
