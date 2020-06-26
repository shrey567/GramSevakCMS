using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AttendanceCMS.Bll.ViewModels.ChildModel.Report
{
    public class AttendenceReportVM
    {

        [DisplayName("Select Employee")]
        public int EmployeeID { get; set; }
        public string Employee { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public List<SelectListItem> EmployeeList { get; set; }
    }
}
