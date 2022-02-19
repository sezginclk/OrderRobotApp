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

namespace OrderRobotApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ICapPublisher _capBus;
        private readonly IRobotTaskManager _robotTaskManager;

        public TaskController(ILogger<TaskController> logger, ICapPublisher capBus, IRobotTaskManager robotTaskManager)
        {
            _logger = logger;
            _capBus = capBus;
            _robotTaskManager = robotTaskManager;
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Task Yaratma İşlemi", Description = "Task Yaratma İşlemi için kullanılır.")]
        public BaseResponse Create(TaskAddUpdateRequest request)
        {
            //task işlemi db de yaratılıyor.
            TaskResponse robotTaskOperation = _robotTaskManager.Add(request);

            //eğer task sorunsuz yaratıldıysa RabbitMq üzerinden işlemin yapılacağı (robotun çalışacağı) servise aktarılıyor
            //bu servis çalışmaya başladığı bilgisini veri tabanına girecek , eğer çalışma anında istek gelirse sıraya koyup reddedecek
            if (robotTaskOperation.Code == (int)ERRORCODES.SUCCESS)
            {
                _capBus.Publish("Operation.CreateOperation.StartTask", new OperationAddUpdateRequest { RobotTaskId = robotTaskOperation.RobotTaskId });

            }

            //eğer başarısız dönerse error code lar üzerinden dönüş sağlanıyor olacak.
            return robotTaskOperation;
        }


        [Route("Update")]
        [HttpPatch]
        [SwaggerOperation(Summary = "task güncelleme işlemi", Description = "task güncelleme işlemi için kullanılır")]
        public TaskResponse Update([FromBody] TaskAddUpdateRequest request)
        {
            TaskResponse result = _robotTaskManager.Update(request);
            return result;
        }

        [Route("Delete")]
        [HttpDelete]
        [SwaggerOperation(Summary = "task silme işlemi", Description = "task silme işlemi için kullanılır.")]
        public BaseResponse Delete([FromBody] int RobotTaskId)
        {
            BaseResponse result = _robotTaskManager.Delete(RobotTaskId);
            return result;
        }

    }
}
