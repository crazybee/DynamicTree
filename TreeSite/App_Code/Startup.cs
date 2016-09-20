using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreeSite.Startup))]
namespace TreeSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
