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

namespace AttendanceCMS.Bll.Services.Services
{
    public interface IScreenServices
    {
        Result EmployeeSave(EmployeeVM _Master);
        DashBoardVM DashBoardDetails();
        List<EmployeeVM> getEmployeeDetails();
        EmployeeVM getEmployeeDetailsByID(int q);
        List<DashBoardVM> getAttendenceDetails();
        List<AttendenceReportVM> getAttendenceReport(string fdate, string tdate, int UserID);
        List<SelectListItem> GetEmployeeList();
    }
}
