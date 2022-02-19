using OrderRobot.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Data.Model.DataTransferObjects.Response
{

    public class BaseResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public void SetErrorToResponse(Constants.ERRORCODES code)
        {
            this.Code = (int)code;
            this.Message = Constants.ErrorCodeData[(int)code];

        }

    }
}
