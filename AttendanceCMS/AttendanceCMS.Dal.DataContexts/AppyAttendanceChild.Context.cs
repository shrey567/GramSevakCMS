﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AppyAttendanceChildEntities : DbContext
    {
        public AppyAttendanceChildEntities(int AppId)
            : base(AttendanceAppConnection.GetConnectionString(AppId))
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Roll> Rolls { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<UserAttendence> UserAttendences { get; set; }
        public virtual DbSet<DeviceDetail> DeviceDetails { get; set; }
    }
}
