using OrderRobot.Data.Contexts;
using OrderRobot.Data.Model.DataTransferObjects.Request;
using OrderRobot.Data.Model.DataTransferObjects.Response;
using OrderRobot.Data.Model.DomainClass;
using OrderRobot.Data.Repositories.Abstract;
using OrderRobot.Data.UnitOfWork;
using OrderRobot.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderRobot.Service.Concrete
{
    public class OperationManager : IOperationManager
    {
        readonly IOperationDal _operationDal;
        readonly IUnitOfWork _unitOfWork;
        readonly MainContext _pbookContext;

        public OperationManager(IOperationDal operationDal, IUnitOfWork unitOfWork, MainContext pbookContext)
        {
            _operationDal = operationDal;
            _unitOfWork = unitOfWork;
            _pbookContext = pbookContext;
        }

        public BaseResponse Add(OperationAddUpdateRequest request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                //çalışmaya başlamak için işleme alındığı bilgisi verilir.
                Operation task = new Operation { RobotTaskId = request.RobotTaskId, Status = (int)Core.Constants.OperationStatus.Initial };
                _operationDal.Add(task);
                int result = _unitOfWork.SaveChanges();
                if (result < 1)
                {
                    //işlem sırasında hata olursa exceptiona atmayabilir.
                    response.SetErrorToResponse(Core.Constants.ERRORCODES.SYSTEMERROR);
                    return response;
                }


                //response içerisine başarılı kodu ve mesajı aktarılıyor
                response.SetErrorToResponse(Core.Constants.ERRORCODES.SUCCESS);
                return response;
            }
            catch (Exception)
            {
                //response içerisine işlem sırasında hata olduğu kodu ve mesajı aktarılıyor
                response.SetErrorToResponse(Core.Constants.ERRORCODES.SYSTEMERROR);
                return response;
            }
        }

        public BaseResponse Update(OperationAddUpdateRequest request)
        {
            TaskResponse response = new TaskResponse();

            try
            {
                //çalışılıyor,hata aldı, tamamlandı güncellemeleri yapılır.
                Operation operation = _operationDal.Table.Where(t => t.RobotTaskId == request.RobotTaskId).FirstOrDefault();
                operation.Status = (int)request.Status;
                _operationDal.Update(operation);
                int result = _unitOfWork.SaveChanges();
                if (result < 1)
                {
                    //işlem sırasında hata olursa exceptiona atmayabilir.
                    response.SetErrorToResponse(Core.Constants.ERRORCODES.SYSTEMERROR);
                    return response;
                }


                //response içerisine başarılı kodu ve mesajı aktarılıyor
                response.SetErrorToResponse(Core.Constants.ERRORCODES.SUCCESS);
                return response;
            }
            catch (Exception)
            {
                //response içerisine işlem sırasında hata olduğu kodu ve mesajı aktarılıyor
                response.SetErrorToResponse(Core.Constants.ERRORCODES.SYSTEMERROR);
                return response;
            }
        }
    }
}
