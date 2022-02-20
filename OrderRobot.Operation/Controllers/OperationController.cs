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
        private readonly IOperationManager _operationManager;

        public OperationController(ILogger<OperationController> logger, ICapPublisher capBus, IOperationManager operationManager)
        {
            _logger = logger;
            _capBus = capBus;
            _operationManager = operationManager;
        }

        [CapSubscribe("Operation.CreateOperation.StartTask")]
        public void StartTaskOperation(OperationAddUpdateRequest request)
        {
            var online = _operationManager.CheckOnOperation();


            //aktif çalışmada olup olmadığı kontrol ediliyor. Eğer çalışmada değilse çalışma ekleniyor.
            if (online.Code == (int)ERRORCODES.READY)
            {
                _operationManager.Add(request); 
            }
        }


    }
}
