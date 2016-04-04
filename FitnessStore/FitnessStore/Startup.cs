using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessStore.Startup))]
namespace FitnessStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
