using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectCostEstimator.Startup))]
namespace ProjectCostEstimator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
