using AttendanceCMS.Bll.Repository.Repository;
using AttendanceCMS.Bll.ViewModels.ChildModel.Admin;
using AttendanceCMS.Bll.ViewModels;
using AttendanceCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceCMS.Models.SessionHelper;

namespace AttendanceCMS.Controllers.Admin
{
    public class AdminController : Controller
    {
        IRepository Repository;
        IMainRepository mainRepository;
        AppyAttendanceMainEntities dbMain = new AppyAttendanceMainEntities();
        AppyAttendanceChildEntities db = new AppyAttendanceChildEntities(1);
        public AdminController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                mainRepository = new MainRepository();
                Repository = new Repository(SessionHandler.Current.AppId);
            }
            else
            {
                Redirect("/Account/Login");
            }
                
        }

        // GET: Admin
        [HttpGet]
        public ActionResult Client(int q = -1)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                var viewModel = new ClientVM();
                viewModel = mainRepository.getClientDetailsByID(q);

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

                var tehsil = new List<SelectListItem>();
                SelectListItem itemTehsil = new SelectListItem() { Text = "Select Tehsil", Value = "0" };
                tehsil = dbMain.Tehsils.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.ID.ToString()
                    }).OrderBy(t => t.Text).ToList();
                tehsil.Insert(0, itemTehsil);
                viewModel.TehsilList = tehsil;

                var language = new List<SelectListItem>();
                SelectListItem itemLanguage = new SelectListItem() { Text = "Select Language", Value = "0" };
                language = dbMain.LanguageInfoes.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Language,
                        Value = x.Id.ToString()
                    }).OrderBy(t => t.Text).ToList();
                language.Insert(0, itemLanguage);
                viewModel.LanguageList = language;

                ViewBag.ReferenceID = DateTime.Now.ToString("yyyyddmmhhmmss");

                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpPost]
        public ActionResult Client(ClientVM _client, HttpPostedFileBase file)
        {

            if (SessionHandler.Current.AppId != 0)
            {
                Result Result = new Result();
                Result = mainRepository.ClientSave(_client);
                return Redirect("/Admin/ClientList");
            }
            else
            {
                return Redirect("/Account/Login");
            }
            
        }


        [HttpGet]
        public ActionResult ClientList()
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
        public JsonResult getClientDetails()
        {
            var griddata = mainRepository.getClientDetails();
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }



    }
}