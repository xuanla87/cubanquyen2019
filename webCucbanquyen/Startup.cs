using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webCucbanquyen.Startup))]
namespace webCucbanquyen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
