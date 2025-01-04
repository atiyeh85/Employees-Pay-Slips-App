using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Salaryv2.Startup))]
namespace Salaryv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
