using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(blockbuster.Startup))]
namespace blockbuster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
