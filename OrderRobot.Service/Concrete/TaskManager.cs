using OrderRobot.Data.Model.DataTransferObjects.Request;
using OrderRobot.Data.Model.DataTransferObjects.Response;
using OrderRobot.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Service.Concrete
{
    public class TaskManager : ITaskManager
    {
        public BaseResponse Add(TaskRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Delete(int RobotoTaskId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Update(TaskRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
