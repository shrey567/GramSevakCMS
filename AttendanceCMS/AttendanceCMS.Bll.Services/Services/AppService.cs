using AttendanceCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceCMS.Bll.Services.Services
{
    public abstract class AppService
    {
        protected AppyAttendanceChildEntities db;
        protected AppyAttendanceMainEntities dbMain;
        public AppService(int AppId)
        {
            db = new AppyAttendanceChildEntities(AppId);
            dbMain = new AppyAttendanceMainEntities();
        }
    }
}
