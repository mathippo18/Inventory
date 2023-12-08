using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inventaire.Startup))]
namespace Inventaire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
