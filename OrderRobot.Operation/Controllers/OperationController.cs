using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderRobot.Data.Model.DataTransferObjects.Request;
using OrderRobot.Data.Model.DataTransferObjects.Response;
using OrderRobot.Service.Abstract;
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
        private readonly IRobotTaskManager _robotTaskManager;

        public OperationController(ILogger<OperationController> logger, ICapPublisher capBus, IRobotTaskManager robotTaskManager)
        {
            _logger = logger;
            _capBus = capBus;
            _robotTaskManager = robotTaskManager;
        }

        [HttpPost("CreateTask")]
        [SwaggerOperation(Summary = "Task Yaratma İşlemi", Description = "Task Yaratma İşlemi için kullanılır.")]
        public BaseResponse CreateTask(TaskAddUpdateRequest request)
        {
            //task işlemi db de yaratılıyor.
            TaskResponse operationReport = _robotTaskManager.Add(request);

            //eğer task sorunsuz yaratıldıysa RabbitMq üzerinden işlemin yapılacağı (robotun çalışacağı servise aktarılıyor)
            //bu servis çalışmaya başladığı bilgisini veri tabanına girecek , eğer çalışma anında istek gelirse sıraya koyup reddedecek
            if (operationReport.Code == (int)ERRORCODES.SUCCESS)
            {
                _capBus.Publish("PhoneBook.Report.Create.DetailedLocationReport",operationReport);

            }

            //eğer başarısız dönerse error code lar üzerinden dönüş sağlanıyor olacak.
            return operationReport;
        }


    }
}
