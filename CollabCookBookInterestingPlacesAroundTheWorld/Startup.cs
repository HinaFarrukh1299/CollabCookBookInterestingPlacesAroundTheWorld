using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollabCookBookInterestingPlacesAroundTheWorld.Startup))]
namespace CollabCookBookInterestingPlacesAroundTheWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
