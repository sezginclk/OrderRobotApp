using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Core
{
    public class Constants
    {


        public enum ERRORCODES
        {
            SUCCESS = 0,
            SYSTEMERROR = 1,
            TASKFOUND = 2,
            LOCATIONNOTFOUND = 3
        }


        public static Dictionary<int, string> ErrorCodeData = new Dictionary<int, string>
        {
            {(int)ERRORCODES.SUCCESS,"İşlem Başarılı. " },
            {(int)ERRORCODES.SYSTEMERROR,"Sistemde Hata Oluştu!" },
            {(int)ERRORCODES.TASKFOUND,"Task bulunamadı!" },
            {(int)ERRORCODES.LOCATIONNOTFOUND,"Lokasyon Bilgisi bulunamadı!" }
        };


        public enum OperationStatus
        {
            Initial = 0,
            Working = 1,
            Error = 2,
            Completed = 3
        }
    }
}
