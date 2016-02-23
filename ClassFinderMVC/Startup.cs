using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassFinderMVC.Startup))]
namespace ClassFinderMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
