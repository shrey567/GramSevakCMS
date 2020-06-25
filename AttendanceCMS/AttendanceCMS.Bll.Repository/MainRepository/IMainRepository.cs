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
    public interface IMainRepository
    {
        int GetUserAppId(int UserId);
        string GetDatabaseFromAppID(int AppId);
        AppDetailsVM GetApplicationDetails(int AppId);
        List<StateVM> getStateDetails();
        Result StateSave(StateVM _Master);
        StateVM getStateDetailsByID(int q);
        Result DistrictSave(DistrictVM _Master);
        DistrictVM getDistrictDetailsByID(int q);
        List<DistrictVM> getDistrictDetails();
        Result TehsilSave(TehsilVM _Master);
        List<TehsilVM> getTehsilDetails();
        TehsilVM getTehsilDetailsByID(int q);
        Result ClientSave(ClientVM _Master);
        EmployeeVM Login(EmployeeVM _userinfo);
        List<ClientVM> getClientDetails();
        ClientVM getClientDetailsByID(int q);
    }
}
