using AttendanceCMS.Dal.DataContexts;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AttendanceCMS
{
    public class NotificationComponent
    {
        public void RegisterNotification(DateTime currentDate)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string sqlCommand = @"SELECT [UserID]
                                  ,[UserName]
                                  ,[EmployeeID]
                                  ,[LoginId]
                                  ,[Password]
                                  ,[Address]
                                  ,[Mobile]
                                  ,[Gender]
                                  ,[Qualification]
                                  ,[Experience]
                                  ,[DOB]
                                  ,[Aadhar]
                                  ,[PAN]
                                  ,[IsActive]
                                  ,[RoleID]
                                  ,[ProfileImage]
                                  ,[CreatedDate]
                              FROM [UserMaster] where [CreatedDate] > @Getdate";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@Getdate", currentDate);
                if(con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Notification = null;
                SqlDependency SqlDep = new SqlDependency(cmd);
                SqlDep.OnChange += sqlDep_OnChange;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                }
            }
        }

        private void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency SqlDep = sender as SqlDependency;
                SqlDep.OnChange -= sqlDep_OnChange;

                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<Notification>();
                notificationHub.Clients.All.notify("added");

                RegisterNotification(DateTime.Now);
            }
        }

        public List<UserMaster> GetUserList(DateTime afterDate)
        {
            using (AppyAttendanceChildEntities dc = new AppyAttendanceChildEntities(1))
            {
                return dc.UserMasters.Where(c => c.CreatedDate > afterDate).OrderByDescending(a => a.CreatedDate).ToList();
            }
        }

    }
}