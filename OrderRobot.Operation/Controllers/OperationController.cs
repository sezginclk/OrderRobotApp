using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderRobot.Data.Model.DataTransferObjects.Request;
using OrderRobot.Data.Model.DataTransferObjects.Response;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OrderRobot.Core.Constants;

namespace OrderRobot.Operation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {

        private readonly ILogger<OperationController> _logger;
        private readonly ICapPublisher _capBus;

        public OperationController(ILogger<OperationController> logger, ICapPublisher capBus)
        {
            _logger = logger;
            _capBus = capBus;
        }

        [HttpPost("CreateTask")]
        [SwaggerOperation(Summary = "Task Yaratma İşlemi", Description = "Task Yaratma İşlemi için kullanılır.")]
        public BaseResponse CreateTask(TaskRequest request)
        {
            ReportResponse operationReport = _reportsManager.Add(personId);
            if (operationReport.Code == (int)ERRORCODES.SUCCESS)
            {
                _capBus.Publish("PhoneBook.Report.Create.DetailedLocationReport", new CreateDetailedLocationReportCommand() { ReportId = operationReport.Id, Location = operationReport.Location });

            }

            return operationReport;
        }


    }
}
