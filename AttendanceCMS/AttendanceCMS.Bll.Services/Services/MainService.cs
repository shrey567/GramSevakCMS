using AttendanceCMS.Bll.ViewModels;
using AttendanceCMS.Bll.ViewModels.ChildModel.Admin;
using AttendanceCMS.Bll.ViewModels.MainModel;
using AttendanceCMS.Bll.ViewModels.Master;
using AttendanceCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceCMS.Bll.Services.Services
{
    public class MainService : AppMainService , IMainService
    {

        public AppDetailsVM GetApplicationDetails(int AppId)
        {
            var appDetails = (dbMain.AppDetails.Where(x => x.AppId == AppId).FirstOrDefault());
            if (appDetails != null)
            {
                return FillAppDetailsVMViewModel(appDetails);
            }
            else
            {
                return null;
            }

        }

        private AppDetailsVM FillAppDetailsVMViewModel(AppDetail data)
        {
            AppDetailsVM model = new AppDetailsVM();
            model.AppId = data.AppId;
            model.AppName = data.AppName;
            model.AppName_mar = data.AppName_mar;
            model.State = data.State;
            model.Tehsil = data.Tehsil;
            model.District = data.District;
            model.EmailId = data.EmailId;
            model.website = data.website;
            model.Android_GCM_pushNotification_Key = data.Android_GCM_pushNotification_Key;
            model.baseImageUrlCMS = data.baseImageUrlCMS;
            model.baseImageUrl = data.baseImageUrl;
            model.basePath = data.basePath;
            model.Latitude = data.Latitude;
            model.Logitude = data.Logitude;
            model.AppVersion = data.AppVersion;
            model.ForceUpdate = data.ForceUpdate;
            model.IsActive = data.IsActive;
            model.LanguageId = data.LanguageId;
            model.CreatedDate = DateTime.Now;
            return model;
        }

        public Result StateSave(StateVM _state)
        {
            Result Result = new Result();
            try
            {
                using (var dbmain = new AppyAttendanceMainEntities())
                {
                    var obj = dbmain.StateMasters.Where(x => x.State_ID == _state.StateID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.State_ID = _state.StateID;
                        obj.State = _state.State;
                        obj.StateMar = _state.StateMar;
                        dbmain.SaveChanges();
                        Result.message = "success";
                    }
                    else
                    {
                        StateMaster Master = new StateMaster();
                        Master.State = _state.State;
                        Master.StateMar = _state.StateMar;
                        dbmain.StateMasters.Add(Master);
                        dbmain.SaveChanges();
                        Result.message = "success";
                    }
                }
            }
            catch
            {
                Result.message = "error";
            }

            return Result;
        }

        public StateVM getStateDetailsByID(int q)
        {
            StateVM data = new StateVM();

            using (var dbmain = new AppyAttendanceMainEntities())
            {
                var task = dbMain.StateMasters.Where(c=>c.State_ID == q).FirstOrDefault();

                if (task != null)
                {
                    data.StateID = task.State_ID;
                    data.State = task.State;
                    data.StateMar = task.StateMar;
                }
            }
            return data;
        }

        public List<StateVM> getStateDetails()
        {
            List<StateVM> Result = new List<StateVM>();
            using (var dbmain = new AppyAttendanceMainEntities())
            {
                var task = dbMain.StateMasters.ToList();

                foreach (var x in task)
                {
                    Result.Add(new StateVM()
                    {
                        StateID = x.State_ID,
                        State = x.State,
                        StateMar = x.StateMar,
                    });
                }
            }
            return Result;
        }

        public Result DistrictSave(DistrictVM _District)
        {
            Result Result = new Result();
            try
            {
                using (var dbmain = new AppyAttendanceMainEntities())
                {
                    var obj = dbmain.Districts.Where(x => x.ID == _District.District_ID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.State_ID = _District.State_ID;
                        obj.District_Name = _District.District_Name;
                        obj.District_Name_Mar = _District.District_Name_Mar;
                        dbmain.SaveChanges();
                        Result.message = "success";
                    }
                    else
                    {
                        District Master = new District();
                        Master.State_ID = _District.State_ID;
                        Master.District_Name = _District.District_Name;
                        Master.District_Name_Mar = _District.District_Name_Mar;
                        dbmain.Districts.Add(Master);
                    }
                        
                    dbmain.SaveChanges();
                    Result.message = "success";
                }
            }
            catch
            {
                Result.message = "error";
            }

            return Result;
        }

        public List<DistrictVM> getDistrictDetails()
        {
            List<DistrictVM> Result = new List<DistrictVM>();
            using (var dbmain = new AppyAttendanceMainEntities())
            {
                var task = dbMain.Districts.ToList();

                foreach (var x in task)
                {
                    Result.Add(new DistrictVM()
                    {
                        District_ID = x.ID,
                        State_ID = x.State_ID,
                        District_Name = x.District_Name,
                        District_Name_Mar = x.District_Name_Mar,
                    });
                }
            }
            return Result;
        }


        public DistrictVM getDistrictDetailsByID(int q)
        {
            DistrictVM data = new DistrictVM();

            using (var dbmain = new AppyAttendanceMainEntities())
            {
                var task = dbMain.Districts.Where(c => c.ID == q).FirstOrDefault();

                if (task != null)
                {
                    data.District_ID = task.ID;
                    data.State_ID = task.State_ID;
                    data.District_Name = task.District_Name;
                    data.District_Name_Mar = task.District_Name_Mar;
                }
            }
            return data;
        }


        public Result TehsilSave(TehsilVM _tehsil)
        {
            Result Result = new Result();
            try
            {
                using (var dbmain = new AppyAttendanceMainEntities())
                {

                    var obj = dbmain.Tehsils.Where(x => x.ID == _tehsil.Tehsil_ID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.Name = _tehsil.Name;
                        obj.Name_Mar = _tehsil.Name_Mar;
                        obj.State_ID = _tehsil.State_ID;
                        obj.District_ID = _tehsil.District_ID;
                        Result.message = "success";
                    }
                    else
                    {
                        Tehsil Master = new Tehsil();
                        Master.Name = _tehsil.Name;
                        Master.Name_Mar = _tehsil.Name_Mar;
                        Master.State_ID = _tehsil.State_ID;
                        Master.District_ID = _tehsil.District_ID;
                        dbmain.Tehsils.Add(Master);
                    }
                    
                    dbmain.SaveChanges();
                    Result.message = "success";
                }
            }
            catch
            {
                Result.message = "error";
            }

            return Result;
        }

        public Result ClientSave(ClientVM _client)
        {
            Result Result = new Result();
            try
            {
                using (var dbmain = new AppyAttendanceMainEntities())
                {
                    var obj = dbmain.AppDetails.Where(x => x.AppId == _client.AppId).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.AppName = _client.AppName;
                        obj.AppName_mar = _client.AppName_mar;
                        obj.State = _client.State;
                        obj.Tehsil = _client.Tehsil;
                        obj.District = _client.District;
                        obj.EmailId = _client.EmailId;
                        obj.website = _client.website;
                        obj.baseImageUrlCMS = _client.baseImageUrlCMS;
                        obj.baseImageUrl = _client.baseImageUrl;
                        obj.basePath = _client.basePath;
                        obj.Latitude = _client.Latitude;
                        obj.Logitude = _client.Logitude;
                        obj.AppVersion = _client.AppVersion;
                        obj.ForceUpdate = _client.ForceUpdate;
                        obj.IsActive = _client.IsActive;
                        obj.LanguageId = _client.LanguageId;
                        obj.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        AppDetail Master = new AppDetail();
                        Master.AppName = _client.AppName;
                        Master.AppName_mar = _client.AppName_mar;
                        Master.State = _client.State;
                        Master.Tehsil = _client.Tehsil;
                        Master.District = _client.District;
                        Master.EmailId = _client.EmailId;
                        Master.website = _client.website;
                        Master.baseImageUrlCMS = _client.baseImageUrlCMS;
                        Master.baseImageUrl = _client.baseImageUrl;
                        Master.basePath = _client.basePath;
                        Master.Latitude = _client.Latitude;
                        Master.Logitude = _client.Logitude;
                        Master.AppVersion = _client.AppVersion;
                        Master.ForceUpdate = _client.ForceUpdate;
                        Master.IsActive = _client.IsActive;
                        Master.LanguageId = _client.LanguageId;
                        Master.CreatedDate = DateTime.Now;
                        dbmain.AppDetails.Add(Master);
                    }
                    dbmain.SaveChanges();
                    Result.message = "success";
                }
            }
            catch
            {
                Result.message = "error";
            }

            return Result;
        }

        public EmployeeVM Login(EmployeeVM _userinfo)
        {
            EmployeeVM _EmployeeVM = new EmployeeVM();
            var appUser = (dbMain.AppUsers.Where(x => x.LoginID == _userinfo.LoginId && x.Password == _userinfo.Password).FirstOrDefault());
            if (appUser != null)
            {
                _EmployeeVM.LoginId = appUser.LoginID;
                _EmployeeVM.AppId = Convert.ToInt32(appUser.AppID);
                _EmployeeVM.UserID = appUser.AppUserID;
                _EmployeeVM.status = "Success";
                return _EmployeeVM;
            }
            else
            {
                _EmployeeVM.status = "Failure";
                return _EmployeeVM;
            }
            return _EmployeeVM;
        }

        public int GetUserAppId(int UserId)
        {
            
            var AppId = dbMain.AppUsers.Where(x => x.AppUserID == UserId).Select(x => x.AppID).FirstOrDefault();

            return int.Parse(AppId.ToString());
        }

        public string GetDatabaseFromAppID(int AppId)
        {
            var DB_Name = dbMain.AppConnections.Where(x => x.AppId == AppId).FirstOrDefault().InitialCatalog;
            return DB_Name.ToString();
        }

        public List<TehsilVM> getTehsilDetails()
        {
            List<TehsilVM> Result = new List<TehsilVM>();
            using (var dbmain = new AppyAttendanceMainEntities())
            {
                var task = (from t in dbmain.Tehsils
                            join s in dbmain.StateMasters on t.State_ID equals s.State_ID
                            join d in dbmain.Districts on t.District_ID equals d.ID
                            select new
                            {
                                t.ID,
                                t.Name,
                                s.State,
                                d.District_Name
                                
                            }).ToList();

                foreach (var x in task)
                {
                    Result.Add(new TehsilVM()
                    {
                        Tehsil_ID = x.ID,
                        Name = x.Name,
                        State = x.State,
                        District = x.District_Name
                    });
                }
            }
            return Result;
        }

        public TehsilVM getTehsilDetailsByID(int q)
        {
            TehsilVM data = new TehsilVM();

            using (var dbmain = new AppyAttendanceMainEntities())
            {
                var task = dbMain.Tehsils.Where(c => c.ID == q).FirstOrDefault();

                if (task != null)
                {
                    data.Name = task.Name;
                    data.Name_Mar = task.Name_Mar;
                    data.State_ID = task.State_ID;
                    data.District_ID = task.District_ID;
                }
            }
            return data;
        }

        public List<ClientVM> getClientDetails()
        {
            List<ClientVM> Result = new List<ClientVM>();
            using (var dbmain = new AppyAttendanceMainEntities())
            {
                var task = (from t in dbmain.AppDetails
                            join s in dbmain.StateMasters on t.State equals s.State_ID
                            join d in dbmain.Districts on t.District equals d.ID
                            select new
                            {
                                t.AppId,
                                t.AppName,
                                t.ReferenceID,
                                t.QrCode,
                                t.EmailId,
                                t.website,
                                t.AppVersion,
                                s.State,
                                d.District_Name

                            }).ToList();

                foreach (var x in task)
                {
                    Result.Add(new ClientVM()
                    {
                        AppId = x.AppId,
                        AppName = x.AppName,
                        ReferenceID = x.ReferenceID,
                        QrCode = x.QrCode,
                        EmailId = x.EmailId,
                        website = x.website,
                        AppVersion = x.AppVersion,
                    });
                }
            }
            return Result;
        }

        public ClientVM getClientDetailsByID(int q)
        {
            ClientVM data = new ClientVM();

            using (var dbmain = new AppyAttendanceMainEntities())
            {
                var task = dbMain.AppDetails.Where(c => c.AppId == q).FirstOrDefault();

                if (task != null)
                {
                    data.AppId = task.AppId;
                    data.AppName = task.AppName;
                    data.AppName_mar = task.AppName_mar;
                    data.State = Convert.ToInt32(task.State);
                    data.Tehsil = Convert.ToInt32(task.Tehsil);
                    data.District = Convert.ToInt32(task.District);
                    data.EmailId = task.EmailId;
                    data.website = task.website;
                    data.Android_GCM_pushNotification_Key = task.Android_GCM_pushNotification_Key;
                    data.baseImageUrlCMS = task.baseImageUrlCMS;
                    data.baseImageUrl = task.baseImageUrl;
                    data.basePath = task.basePath;
                    data.Latitude = task.Latitude;
                    data.Logitude = task.Logitude;
                    data.AppVersion = task.AppVersion;
                    data.ForceUpdate = Convert.ToBoolean(task.ForceUpdate);
                    data.IsActive = Convert.ToBoolean(task.IsActive);
                    data.LanguageId = Convert.ToInt32(task.LanguageId);
                    data.QrCode = task.QrCode;
                    data.ReferenceID = task.ReferenceID;
                }
            }
            return data;
        }

    }
}
