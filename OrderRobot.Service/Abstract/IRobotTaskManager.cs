using OrderRobot.Data.Model.DataTransferObjects.Request;
using OrderRobot.Data.Model.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Service.Abstract
{
    public interface IRobotTaskManager
    {
        TaskResponse Add(TaskAddUpdateRequest request);
        TaskResponse Update(TaskAddUpdateRequest request);
        BaseResponse Delete(int RobotTaskId);
    }
}
