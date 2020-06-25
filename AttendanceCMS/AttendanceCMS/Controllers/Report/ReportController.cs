using AttendanceCMS.Bll.Repository.Repository;
using AttendanceCMS.Bll.ViewModels.ChildModel.Report;
using AttendanceCMS.Models.SessionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceCMS.Controllers.Report
{
    public class ReportController : Controller
    {

        IRepository Repository;
        // GET: Report
        public ReportController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Repository = new Repository(SessionHandler.Current.AppId);
            }
            else
                Redirect("/Account/Login");
        }
        public ActionResult AttendenceReport()
        {
            AttendenceReportVM model = new AttendenceReportVM();
            model.EmployeeList = Repository.GetEmployeeList();
            return View(model);
        }

        [HttpGet]
        public JsonResult getAttendenceReport(string fdate, string tdate,int UserID)
        {
            var griddata = Repository.getAttendenceReport(fdate, tdate, UserID);
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }


    }
}