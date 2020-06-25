using AttendanceCMS.Bll.ViewModels;
using AttendanceCMS.Bll.ViewModels.ChildModel.Admin;
using AttendanceCMS.Bll.ViewModels.MainModel;
using AttendanceCMS.Bll.ViewModels.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceCMS.Bll.Services.Services
{
    public interface IMainService
    {
        AppDetailsVM GetApplicationDetails(int AppId);
        
        Result StateSave(StateVM _state);
        StateVM getStateDetailsByID(int q);
        List<StateVM> getStateDetails();
        Result DistrictSave(DistrictVM _District);
        List<DistrictVM> getDistrictDetails();
        DistrictVM getDistrictDetailsByID(int q);
        Result TehsilSave(TehsilVM _tehsil);
        List<TehsilVM> getTehsilDetails();
        TehsilVM getTehsilDetailsByID(int q);
        Result ClientSave(ClientVM _client);
        EmployeeVM Login(EmployeeVM _userinfo);
        int GetUserAppId(int UserId);
        string GetDatabaseFromAppID(int AppId);
        List<ClientVM> getClientDetails();
        ClientVM getClientDetailsByID(int q);

    }
}
