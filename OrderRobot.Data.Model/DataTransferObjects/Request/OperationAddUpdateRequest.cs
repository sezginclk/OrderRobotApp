using System;
using System.Collections.Generic;
using System.Text;
using static OrderRobot.Core.Constants;

namespace OrderRobot.Data.Model.DataTransferObjects.Request
{
    public class OperationAddUpdateRequest
    {
        public int RobotTaskId { get; set; }
        public OperationStatus Status { get; set; }
    }
}
