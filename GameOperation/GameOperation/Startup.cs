using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameOperation.Startup))]
namespace GameOperation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
