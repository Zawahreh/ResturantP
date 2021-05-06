using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(storev.Startup))]
namespace storev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
