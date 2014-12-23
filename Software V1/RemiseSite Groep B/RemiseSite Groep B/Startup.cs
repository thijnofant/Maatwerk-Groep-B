using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RemiseSite_Groep_B.Startup))]
namespace RemiseSite_Groep_B
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
