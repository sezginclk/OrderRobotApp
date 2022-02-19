using OrderRobot.Data.Contexts;
using OrderRobot.Data.Model.DomainClass;
using OrderRobot.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Data.Repositories.Concrete
{
    public class RobotTaskDal : EFRepository<RobotTask>, IRobotTaskDal
    {
        public RobotTaskDal(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
