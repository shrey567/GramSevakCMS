using AttendanceCMS.Bll.Repository.Repository;
using AttendanceCMS.Bll.ViewModels.Master;
using AttendanceCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceCMS.Bll.ViewModels;
using System.IO;
using AttendanceCMS.Models.SessionHelper;

namespace AttendanceCMS.Controllers.Master
{
    public class MasterController : Controller
    {

        IRepository Repository;
        IMainRepository mainRepository;
        AppyAttendanceMainEntities dbMain = new AppyAttendanceMainEntities();
        AppyAttendanceChildEntities db = new AppyAttendanceChildEntities(1);
        public MasterController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                mainRepository = new MainRepository();
                Repository = new Repository(SessionHandler.Current.AppId);
            }
            else
                Redirect("/Account/Login");
        }
        
        // GET: Master
        [HttpGet]
        public ActionResult Employee(int q = -1)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                var viewModel = new EmployeeVM();
                viewModel = Repository.getEmployeeDetailsByID(q);
                var Role = new List<SelectListItem>();
                SelectListItem itemRole = new SelectListItem() { Text = "Select Role", Value = "0" };
                Role = db.Rolls.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Role,
                        Value = x.RoleID.ToString()
                    }).OrderBy(t => t.Text).ToList();
                Role.Insert(0, itemRole);

                viewModel.RoleList = Role;

                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }

        }

        [HttpPost]

        public ActionResult Employee(EmployeeVM Employee, HttpPostedFileBase file)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                if (file != null && file.ContentLength > 0)
                {
                    int AppId = int.Parse(SessionHandler.Current.AppId.ToString());
                    var AppDetails = mainRepository.GetApplicationDetails(AppId);
                    var _Extensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

                    var fileName = Path.GetFileName(file.FileName);
                    var ext = Path.GetExtension(file.FileName);
                    if (_Extensions.Contains(ext))
                    {
                        //Guid Random = Guid.NewGuid();
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = name + ext;

                        //var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"));
                        var exists = System.IO.Directory.Exists(Server.MapPath("~/Images"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Images"));
                        }
                        var path = Path.Combine(Server.MapPath("~/Images"), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Employee.ProfileImage = myfile;
                        file.SaveAs(path);
                    }
                }
                

                Result Result = new Result();
                Result = Repository.EmployeeSave(Employee);
                ViewBag.Message = Result.message;

                return Redirect("/Master/EmployeeList");
            }
            else
            {
                return Redirect("/Account/Login");
            }

        }


        [HttpGet]
        public ActionResult EmployeeList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }


        [HttpGet]
        public JsonResult getEmployeeDetails()
        {
            var griddata = Repository.getEmployeeDetails();
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult State(int q = -1)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                var viewModel = new StateVM();
                viewModel = mainRepository.getStateDetailsByID(q);
                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpGet]
        public JsonResult getStateDetails()
        {
            var griddata = mainRepository.getStateDetails();
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult State(StateVM _state)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Result Result = new Result();
                Result = mainRepository.StateSave(_state);
                return Redirect("/Master/StateList");
            }
            else
            {
                return Redirect("/Account/Login");
            }
           
        }


        [HttpGet]
        public ActionResult StateList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }


        [HttpGet]
        public ActionResult District(int q = -1)
        {

            if (SessionHandler.Current.AppId != 0)
            {
                var viewModel = new DistrictVM();
                viewModel = mainRepository.getDistrictDetailsByID(q);
                var state = new List<SelectListItem>();
                SelectListItem itemstate = new SelectListItem() { Text = "Select State", Value = "0" };
                state = dbMain.StateMasters.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.State,
                        Value = x.State_ID.ToString()
                    }).OrderBy(t => t.Text).ToList();
                state.Insert(0, itemstate);

                viewModel.StateList = state;

                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }
            
        }


        [HttpPost]
        public ActionResult District(DistrictVM _district)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Result Result = new Result();
                Result = mainRepository.DistrictSave(_district);
                return Redirect("/Master/District");
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }


        [HttpGet]
        public JsonResult getDistrictDetails()
        {
            var griddata = mainRepository.getDistrictDetails();
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DistrictList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }



        [HttpGet]
        public ActionResult Tehsil(int q = -1)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                var viewModel = new TehsilVM();
                viewModel = mainRepository.getTehsilDetailsByID(q);
                var state = new List<SelectListItem>();
                SelectListItem itemstate = new SelectListItem() { Text = "Select State", Value = "0" };
                state = dbMain.StateMasters.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.State,
                        Value = x.State_ID.ToString()
                    }).OrderBy(t => t.Text).ToList();
                state.Insert(0, itemstate);
                viewModel.StateList = state;

                var district = new List<SelectListItem>();
                SelectListItem itemdistrict = new SelectListItem() { Text = "Select District", Value = "0" };
                district = dbMain.Districts.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.District_Name,
                        Value = x.ID.ToString()
                    }).OrderBy(t => t.Text).ToList();
                district.Insert(0, itemdistrict);
                viewModel.DistrictList = district;

                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }


        [HttpPost]
        public ActionResult Tehsil(TehsilVM TehsilVM)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Result Result = new Result();
                Result = mainRepository.TehsilSave(TehsilVM);
                return Redirect("/Master/TehsilList");
            }
            else
            {
                return Redirect("/Account/Login");
            }
            
        }


        [HttpGet]
        public ActionResult TehsilList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpGet]
        public JsonResult getTehsilDetails()
        {
            var griddata = mainRepository.getTehsilDetails();
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getClientDetails()
        {
            var griddata = mainRepository.getClientDetails();
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }


    }
}