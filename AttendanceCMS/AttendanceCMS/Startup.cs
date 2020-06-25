using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttendanceCMS.Startup))]
namespace AttendanceCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
