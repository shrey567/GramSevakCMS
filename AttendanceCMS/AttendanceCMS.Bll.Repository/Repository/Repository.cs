using AttendanceCMS.Bll.Services.Services;
using AttendanceCMS.Bll.ViewModels;
using AttendanceCMS.Bll.ViewModels.ChildModel;
using AttendanceCMS.Bll.ViewModels.ChildModel.Report;
using AttendanceCMS.Bll.ViewModels.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AttendanceCMS.Bll.Repository.Repository
{
    public class Repository : IRepository
    {
        private int AppID;
        IScreenServices screenService;

        public Repository(int AppId)
        {
            screenService = new ScreenServices(AppId);

            AppID = AppId;
        }


        public Result EmployeeSave(EmployeeVM _Master)
        {
            Result result = screenService.EmployeeSave(_Master);
            return result;
        }

        public List<EmployeeVM> getEmployeeDetails()
        {
            List<EmployeeVM> Result = new List<EmployeeVM>();
            Result = screenService.getEmployeeDetails();
            return Result;
        }

        public EmployeeVM getEmployeeDetailsByID(int q)
        {
            EmployeeVM Result = new EmployeeVM();
            Result = screenService.getEmployeeDetailsByID(q);
            return Result;
        }

        public DashBoardVM DashBoardDetails()
        {
            DashBoardVM result = screenService.DashBoardDetails();
            return result;
        }

        public List<DashBoardVM> getAttendenceDetails()
        {
            List<DashBoardVM> Result = new List<DashBoardVM>();
            Result = screenService.getAttendenceDetails();
            return Result;
        }
        public List<AttendenceReportVM> getAttendenceReport(string fdate, string tdate, int UserID)
        {
            List<AttendenceReportVM> Result = new List<AttendenceReportVM>();
            Result = screenService.getAttendenceReport(fdate, tdate, UserID);
            return Result;
        }

        public List<SelectListItem> GetEmployeeList()
        {
            List<SelectListItem> Result = new List<SelectListItem>();
            Result = screenService.GetEmployeeList();
            return Result;
        }
    }
}
