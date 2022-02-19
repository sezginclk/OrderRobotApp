using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderRobot.Operation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {

        private readonly ILogger<OperationController> _logger;

        public OperationController(ILogger<OperationController> logger)
        {
            _logger = logger;
        }


    }
}
