using AttendanceCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceCMS.Bll.Services.Services
{
    public abstract class AppMainService
    {
        protected AppyAttendanceMainEntities dbMain;
        public AppMainService()
        {
            dbMain = new AppyAttendanceMainEntities();
        }
    }
}
