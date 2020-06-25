using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceCMS.Bll.ViewModels.MainModel
{
    public class AppDetailsVM
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public string AppName_mar { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> Tehsil { get; set; }
        public Nullable<int> District { get; set; }
        public string EmailId { get; set; }
        public string website { get; set; }
        public string Android_GCM_pushNotification_Key { get; set; }
        public string baseImageUrlCMS { get; set; }
        public string baseImageUrl { get; set; }
        public string basePath { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
        public string AppVersion { get; set; }
        public Nullable<bool> ForceUpdate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
