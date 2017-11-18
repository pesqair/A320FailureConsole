using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A320FailureConsole.Startup))]
namespace A320FailureConsole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
