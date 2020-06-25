using AttendanceCMS.Bll.ViewModels;
using AttendanceCMS.Bll.ViewModels.ChildModel;
using AttendanceCMS.Bll.ViewModels.ChildModel.Report;
using AttendanceCMS.Bll.ViewModels.Master;
using AttendanceCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AttendanceCMS.Bll.Services.Services
{
    public class ScreenServices : AppService, IScreenServices
    {

        private int AppID;
        public ScreenServices(int AppId) : base(AppId)
        {
            AppID = AppId;
        }

        public Result EmployeeSave(EmployeeVM _Master)
        {
            Result Result = new Result();
            try
            {
                using (var db = new AppyAttendanceChildEntities(AppID))
                {
                    var obj = db.UserMasters.Where(x => x.UserID == _Master.UserID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserName = _Master.UserName;
                        obj.EmployeeID = _Master.EmployeeID;
                        obj.LoginId = _Master.LoginId;

                        obj.Password = _Master.Password;
                        obj.Address = _Master.Address;
                        obj.Mobile = _Master.Mobile;
                        obj.Gender = _Master.Gender;
                        obj.Qualification = _Master.Qualification;
                        obj.Experience = _Master.Experience;

                        obj.DOB = _Master.DOB;
                        obj.Aadhar = _Master.Aadhar;
                        obj.PAN = _Master.PAN;
                        obj.IsActive = _Master.IsActive;
                        obj.RoleID = _Master.RoleID;
                        obj.ProfileImage = _Master.ProfileImage;
                        obj.CreatedDate = DateTime.Now;

                    }
                    else
                    {
                        UserMaster Master = new UserMaster();
                        Master.UserName = _Master.UserName;
                        Master.EmployeeID = _Master.EmployeeID;
                        Master.LoginId = _Master.LoginId;

                        Master.Password = _Master.Password;
                        Master.Address = _Master.Address;
                        Master.Mobile = _Master.Mobile;
                        Master.Gender = _Master.Gender;
                        Master.Qualification = _Master.Qualification;
                        Master.Experience = _Master.Experience;

                        Master.DOB = _Master.DOB;
                        Master.Aadhar = _Master.Aadhar;
                        Master.PAN = _Master.PAN;
                        Master.IsActive = _Master.IsActive;
                        Master.RoleID = _Master.RoleID;
                        Master.ProfileImage = _Master.ProfileImage;
                        Master.CreatedDate = DateTime.Now;

                        db.UserMasters.Add(Master);
                    }


                    db.SaveChanges();
                    Result.message = "success";
                }
            }
            catch
            {
                Result.message = "error";
            }

            return Result;
        }

        public DashBoardVM DashBoardDetails()
        {
            DashBoardVM Result = new DashBoardVM();

            using (var db = new AppyAttendanceChildEntities(AppID))
            {
                var UserAttendence = db.UserAttendences.Where(c => EntityFunctions.TruncateTime(c.InDateTime) == EntityFunctions.TruncateTime(DateTime.Now) & c.OutDateTime == null).GroupBy(x => x.UserID).Count();
                var TotalUser = db.UserMasters.Count();

                Result.Attendence = UserAttendence + "/" + TotalUser;

            }
            return Result;
        }

        public List<EmployeeVM> getEmployeeDetails()
        {
            List<EmployeeVM> Result = new List<EmployeeVM>();
            using (var db = new AppyAttendanceChildEntities(AppID))
            {
                var task = (from u in db.UserMasters
                            select new
                            {
                                u.UserID,
                                u.UserName,
                                u.EmployeeID,
                                u.Address,
                                u.Mobile,

                            }).ToList();

                foreach (var x in task)
                {
                    Result.Add(new EmployeeVM()
                    {
                        UserID = x.UserID,
                        UserName = x.UserName,
                        EmployeeID = x.EmployeeID,
                        Address = x.Address,
                        Mobile = x.Mobile
                    });
                }
            }
            return Result;
        }

        public EmployeeVM getEmployeeDetailsByID(int q)
        {
            EmployeeVM data = new EmployeeVM();
            using (var db = new AppyAttendanceChildEntities(AppID))
            {
                var task = db.UserMasters.Where(c => c.UserID == q).FirstOrDefault();

                if (task != null)
                {
                    data.UserID = task.UserID;
                    data.UserName = task.UserName;
                    data.EmployeeID = task.EmployeeID;
                    data.LoginId = task.LoginId;
                    data.Password = task.Password;
                    data.Address = task.Address;
                    data.Mobile = task.Mobile;
                    data.Gender = task.Gender;
                    data.Qualification = task.Qualification;
                    data.Experience = task.Experience;
                    data.DOB = Convert.ToDateTime(task.DOB);
                    data.Aadhar = task.Aadhar;
                    data.PAN = task.PAN;
                    data.IsActive = Convert.ToBoolean(task.IsActive);
                    data.RoleID = Convert.ToInt32(task.RoleID);
                    data.ProfileImage = task.ProfileImage;
                }
            }
            return data;
        }

        public List<DashBoardVM> getAttendenceDetails()
        {
            List<DashBoardVM> Result = new List<DashBoardVM>();

            using (var db = new AppyAttendanceChildEntities(AppID))
            {

                var UserAttendence = (from UA in db.UserAttendences
                                      join UM in db.UserMasters on UA.UserID equals UM.UserID
                                      where EntityFunctions.TruncateTime(UA.InDateTime) == EntityFunctions.TruncateTime(DateTime.Now)
                                      select new
                                      {
                                          UserName = UM.UserName,
                                          InTime = UA.InDateTime,
                                          InLat = UA.InLat,
                                          InLong = UA.InLong
                                      }).ToList();


                foreach (var x in UserAttendence)
                {
                    Result.Add(new DashBoardVM()
                    {
                        UserName = x.UserName,
                        InTime = Convert.ToDateTime(x.InTime).ToString("hh:mm tt"),
                        InLat = x.InLat.ToString(),
                        InLong = x.InLong.ToString(),
                    });
                }
            }
            return Result;
        }

        public List<AttendenceReportVM> getAttendenceReport(string fdate, string tdate, int UserID)
        {
            List<AttendenceReportVM> Result = new List<AttendenceReportVM>();

            using (var db = new AppyAttendanceChildEntities(AppID))
            {
                //DateTime fdate = Convert.ToDateTime(dt + " " + "00:00:00");
                //DateTime tdate = Convert.ToDateTime(dt + " " + "23:59:59");

                DateTime fromDate = DateTime.ParseExact(fdate, "d/M/yyyy", CultureInfo.InvariantCulture);
                DateTime _fdate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 00, 00, 00, 000);  //Today at 00:00:00

                //DateTime _fdate = DateTime.ParseExact(fdate, "d/M/yyyy", CultureInfo.InvariantCulture);//Convert.ToDateTime(fdate);
                DateTime Dateeee = DateTime.ParseExact(tdate, "d/M/yyyy", CultureInfo.InvariantCulture); 
                DateTime _tdate = new DateTime(Dateeee.Year, Dateeee.Month, Dateeee.Day, 23, 59, 59, 999); // Dateeee.AddDays(1).AddTicks

                //DateTime _tdate = DateTime.ParseExact(tdate, "d/M/yyyy", CultureInfo.InvariantCulture);//Convert.ToDateTime(tdate);

                if (UserID > 0)
                {
                    var UserAttendence = (from UA in db.UserAttendences
                                          join UM in db.UserMasters on UA.UserID equals UM.UserID
                                          where UA.InDateTime >= _fdate & UA.InDateTime < _tdate & UA.UserID == UserID
                                          select new
                                          {
                                              Employee = UM.UserName,
                                              StartDate = UA.InDateTime,
                                              InTime = UA.InDateTime,
                                              OutTime = UA.OutDateTime,
                                              InLat = UA.InLat,
                                              InLong = UA.InLong,
                                              CreatedDate = UA.CreatedDate
                                          }).OrderByDescending(d => d.CreatedDate).ToList();


                    foreach (var x in UserAttendence)
                    {
                        Result.Add(new AttendenceReportVM()
                        {
                            Employee = x.Employee,
                            StartDate = Convert.ToDateTime(x.InTime).ToString("dd/MM/yyyy"),
                            StartTime = Convert.ToDateTime(x.InTime).ToString("hh:mm tt"),
                            EndTime = Convert.ToDateTime(x.OutTime).ToString("hh:mm tt"),
                            Lat = x.InLat.ToString(),
                            Long = x.InLong.ToString(),
                        });
                    }
                }
                else
                {
                    var UserAttendence = (from UA in db.UserAttendences
                                          join UM in db.UserMasters on UA.UserID equals UM.UserID
                                          where UA.InDateTime >= _fdate & UA.InDateTime < _tdate
                                          select new
                                          {
                                              Employee = UM.UserName,
                                              StartDate = UA.InDateTime,
                                              InTime = UA.InDateTime,
                                              OutTime = UA.OutDateTime,
                                              InLat = UA.InLat,
                                              InLong = UA.InLong,
                                              CreatedDate = UA.CreatedDate
                                          }).OrderByDescending(d => d.CreatedDate).ToList();


                    foreach (var x in UserAttendence)
                    {
                        Result.Add(new AttendenceReportVM()
                        {
                            Employee = x.Employee,
                            StartDate = Convert.ToDateTime(x.InTime).ToString("dd/MM/yyyy"),
                            StartTime = Convert.ToDateTime(x.InTime).ToString("hh:mm tt"),
                            EndTime = (x.OutTime == null ? "" : Convert.ToDateTime(x.OutTime).ToString("hh:mm tt")),
                            Lat = x.InLat.ToString(),
                            Long = x.InLong.ToString(),
                        });
                    }
                }

            }
            return Result;
        }

        public List<SelectListItem> GetEmployeeList()
        {
            List<SelectListItem> employee = new List<SelectListItem>();

            using (var db = new AppyAttendanceChildEntities(AppID))
            {
                SelectListItem items = new SelectListItem() { Text = "Select Employee", Value = "0" };
                employee = db.UserMasters.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.UserName,
                        Value = x.UserID.ToString()
                    }).OrderBy(t => t.Text).ToList();
                employee.Insert(0, items);
            }

            return employee;

        }

    }
}
