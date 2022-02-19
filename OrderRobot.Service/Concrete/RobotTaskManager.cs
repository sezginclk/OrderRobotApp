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
    public class RobotTaskManager : IRobotTaskManager
    {
        readonly IRobotTaskDal _robotTaskDal;
        readonly IUnitOfWork _unitOfWork;
        readonly MainContext _pbookContext;

        public RobotTaskManager(IRobotTaskDal robotTaskDal, IUnitOfWork unitOfWork, MainContext pbookContext)
        {
            _robotTaskDal = robotTaskDal;
            _unitOfWork = unitOfWork;
            _pbookContext = pbookContext;
        }


        public TaskResponse Add(TaskAddUpdateRequest request)
        {
            TaskResponse response = new TaskResponse();

            try
            {
                RobotTask task = new RobotTask { LocationCode = request.LocationCode, Unit = request.Unit };
                _robotTaskDal.Add(task);
                int result = _unitOfWork.SaveChanges();
                if (result < 1)
                {
                    //işlem sırasında hata olursa exceptiona atmayabilir.
                    response.SetErrorToResponse(Core.Constants.ERRORCODES.SYSTEMERROR);
                    return response;
                }
                response.RobotTaskId = task.RobotTaskId;


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


        public TaskResponse Update(TaskAddUpdateRequest request)
        {
            TaskResponse response = new TaskResponse();

            try
            {
                RobotTask task = _robotTaskDal.Table.Where(t => t.RobotTaskId == request.RobotTaskId).FirstOrDefault();
                task.LocationCode = request.LocationCode;
                task.Unit = request.Unit;
                _robotTaskDal.Update(task);
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


        public BaseResponse Delete(int RobotTaskId)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                RobotTask task = _robotTaskDal.Table.Where(t => t.RobotTaskId == RobotTaskId).FirstOrDefault();
                _robotTaskDal.Delete(task);
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
