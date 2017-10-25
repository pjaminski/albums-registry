using System.Data.Entity;
using AlbumsRegistry.DAL;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlbumsRegistry.Startup))]
namespace AlbumsRegistry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            DbContext context = new AlbumsRegistryDbContext();
        }
    }
}
