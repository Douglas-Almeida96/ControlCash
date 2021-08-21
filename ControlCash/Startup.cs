using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlCash.Startup))]
namespace ControlCash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}