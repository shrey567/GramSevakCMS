using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AttendanceCMS.Bll.ViewModels.Master
{
    public class MasterVM
    {
    }
    public class EmployeeVM
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmployeeID { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public DateTime DOB { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public bool IsActive { get; set; }
        public int RoleID { get; set; }
        public List<SelectListItem> RoleList { get; set; }
        public string ProfileImage { get; set; }
        public string QrImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string status { get; set; }
        public int AppId { get; set; }

    }
    public class StateVM
    {
        public int StateID { get; set; }
        public string State { get; set; }
        public string StateMar { get; set; }
    }

    public class DistrictVM
    {
        public int District_ID { get; set; }
        [DisplayName("State")]
        public int State_ID { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public string District_Name { get; set; }
        public string District_Name_Mar { get; set; }
    }

    public class TehsilVM
    {
        public int Tehsil_ID { get; set; }
        public string Name { get; set; }
        public string Name_Mar { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<int> State_ID { get; set; }
        public string State { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public Nullable<int> District_ID { get; set; }
        public string District { get; set; }
        public List<SelectListItem> DistrictList { get; set; }
    }
}
