using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhenWillIGetThere.Startup))]
namespace WhenWillIGetThere
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
