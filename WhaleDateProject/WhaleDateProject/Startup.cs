using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhaleDateProject.Startup))]
namespace WhaleDateProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
