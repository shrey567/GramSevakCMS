//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AttendanceCMS.Dal.DataContexts
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppDetail
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
        public Nullable<bool> IsProduction { get; set; }
        public string baseImageUrlCMS { get; set; }
        public string baseImageUrl { get; set; }
        public string basePath { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
        public string AppVersion { get; set; }
        public Nullable<bool> ForceUpdate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string QrCode { get; set; }
        public string ReferenceID { get; set; }
    }
}
