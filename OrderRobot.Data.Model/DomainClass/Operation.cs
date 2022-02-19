using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OrderRobot.Core.Constants;

namespace OrderRobot.Data.Model.DomainClass
{
    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }

        public int RobotTaskId { get; set; }

        public OperationStatus Status { get; set; }

    }
}
