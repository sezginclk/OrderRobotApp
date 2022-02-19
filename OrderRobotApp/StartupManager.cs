using Microsoft.Extensions.DependencyInjection;
using OrderRobot.Data.Contexts;
using OrderRobot.Data.Repositories.Abstract;
using OrderRobot.Data.Repositories.Concrete;
using OrderRobot.Data.UnitOfWork;
using OrderRobot.Service.Abstract;
using OrderRobot.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderRobotApp
{
    public static class StartupManager
    {
        public static IServiceCollection AddDependencyToService(this IServiceCollection services)
        {
            #region ContainerObject

            services.AddScoped<IRobotTaskManager, RobotTaskManager>();
            services.AddScoped<IOperationManager, OperationManager>();
            services.AddScoped<IRobotTaskDal, RobotTaskDal>();
            services.AddScoped<IOperationDal, OperationDal>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<MainContext>();


            #endregion

            return services;
        }
    }
}
