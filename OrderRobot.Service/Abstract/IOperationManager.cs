using OrderRobot.Data.Model.DataTransferObjects.Request;
using OrderRobot.Data.Model.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Service.Abstract
{
    public interface IOperationManager
    {
        BaseResponse Add(OperationAddUpdateRequest request);
        BaseResponse Update(OperationAddUpdateRequest request);
        BaseResponse CheckOnOperation();
    }
}
