using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TIQRI.Devday.Startup))]
namespace TIQRI.Devday
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
