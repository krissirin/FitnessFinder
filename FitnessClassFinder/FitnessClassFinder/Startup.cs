using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessClassFinder.Startup))]
namespace FitnessClassFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
