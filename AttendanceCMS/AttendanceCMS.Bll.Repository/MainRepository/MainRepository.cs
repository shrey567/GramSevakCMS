using AttendanceCMS.Bll.Services.Services;
using AttendanceCMS.Bll.ViewModels;
using AttendanceCMS.Bll.ViewModels.ChildModel.Admin;
using AttendanceCMS.Bll.ViewModels.MainModel;
using AttendanceCMS.Bll.ViewModels.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceCMS.Bll.Repository.Repository
{
    public class MainRepository : IMainRepository
    {

        IMainService mainService;
        
        public MainRepository()
        {
            mainService = new MainService();
        }
        public AppDetailsVM GetApplicationDetails(int AppId)
        {
            return mainService.GetApplicationDetails(AppId);
        }

        public Result StateSave(StateVM _state)
        {
            Result result = mainService.StateSave(_state);
            return result;
        }

        public StateVM getStateDetailsByID(int q)
        {
            StateVM data = new StateVM();
            return data = mainService.getStateDetailsByID(q);
        }

        public Result DistrictSave(DistrictVM _Master)
        {
            Result result = mainService.DistrictSave(_Master);
            return result;
        }

        public DistrictVM getDistrictDetailsByID(int q)
        {
            DistrictVM data = new DistrictVM();
            return data = mainService.getDistrictDetailsByID(q);
        }

        public Result TehsilSave(TehsilVM _Master)
        {
            Result result = mainService.TehsilSave(_Master);
            return result;
        }

        public TehsilVM getTehsilDetailsByID(int q)
        {
            TehsilVM data = new TehsilVM();
            return data = mainService.getTehsilDetailsByID(q);
        }

        public Result ClientSave(ClientVM _Master)
        {
            Result result = mainService.ClientSave(_Master);
            return result;
        }

        public EmployeeVM Login(EmployeeVM _userinfo)
        {
            EmployeeVM result = mainService.Login(_userinfo);
            return result;
        }

        
        public int GetUserAppId(int UserId)
        {
            return mainService.GetUserAppId(UserId);
        }

        public string GetDatabaseFromAppID(int AppId)
        {
            return mainService.GetDatabaseFromAppID(AppId);
        }

        public List<StateVM> getStateDetails()
        {
            List<StateVM> Result = new List<StateVM>();
            Result = mainService.getStateDetails();
            return Result;
        }

        public List<DistrictVM> getDistrictDetails()
        {
            List<DistrictVM> Result = new List<DistrictVM>();
            Result = mainService.getDistrictDetails();
            return Result;
        }

        public List<TehsilVM> getTehsilDetails()
        {
            List<TehsilVM> Result = new List<TehsilVM>();
            Result = mainService.getTehsilDetails();
            return Result;
        }

        public List<ClientVM> getClientDetails()
        {
            List<ClientVM> Result = new List<ClientVM>();
            Result = mainService.getClientDetails();
            return Result;
        }

        public ClientVM getClientDetailsByID(int q)
        {
            ClientVM data = new ClientVM();
            return data = mainService.getClientDetailsByID(q);
        }

    }
}
