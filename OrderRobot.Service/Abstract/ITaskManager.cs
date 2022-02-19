using OrderRobot.Data.Model.DataTransferObjects.Request;
using OrderRobot.Data.Model.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Service.Abstract
{
    public interface ITaskManager
    {
        BaseResponse Add(TaskRequest request);
        BaseResponse Update(TaskRequest request);
        BaseResponse Delete(int RobotoTaskId);
    }
}
