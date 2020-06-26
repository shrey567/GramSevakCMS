using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceCMS.Bll.ViewModels.ChildModel
{
    public class DashBoardVM
    {
        public string Attendence { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
        public string Mobile { get; set; }
        public string InTime { get; set; }
        public string InLat { get; set; }
        public string InLong { get; set; }
    }
}
