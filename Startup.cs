using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoRe.Startup))]
namespace MoRe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
