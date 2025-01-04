using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalaryV2.Startup))]
namespace SalaryV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
