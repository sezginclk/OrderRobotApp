using OrderRobot.Data.Contexts;
using OrderRobot.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderRobot.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        MainContext GetContext();
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
