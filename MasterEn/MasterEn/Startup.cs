using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterEn.Startup))]
namespace MasterEn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
