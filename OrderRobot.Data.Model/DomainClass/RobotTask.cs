using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderRobot.Data.Model.DomainClass
{
    public class RobotTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RobotTaskId { get; set; }

        public int LocationCode { get; set; }

        public int Unit { get; set; }

    }
}
