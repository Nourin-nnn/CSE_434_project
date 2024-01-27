using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSE_434_project.Startup))]
namespace CSE_434_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
