using OrderRobot.Data.Contexts;
using OrderRobot.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderRobot.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MainContext _mainContext;
        public MainContext GetContext()
        {
            return _mainContext;
        }


        public EFUnitOfWork(MainContext mainContext)
        {
            //dbContext.Database.SetInitializer<DbContext>(null);

            if (mainContext == null)
                throw new ArgumentNullException("mainContext can not be null.");

            _mainContext = mainContext;

            // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.

        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_mainContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _mainContext.SaveChanges();
            }
            catch
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _mainContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }

        #endregion

        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _mainContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion



    }
}
