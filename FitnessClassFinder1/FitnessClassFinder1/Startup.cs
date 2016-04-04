using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessClassFinder1.Startup))]
namespace FitnessClassFinder1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
