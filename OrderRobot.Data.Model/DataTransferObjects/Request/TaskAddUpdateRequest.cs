using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Data.Model.DataTransferObjects.Request
{
    public class TaskAddUpdateRequest
    {
        public int RobotTaskId { get; set; }
        public int LocationCode { get; set; }
        public int Unit { get; set; }
    }
}
