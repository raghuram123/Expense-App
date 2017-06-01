using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpensesApp.Startup))]
namespace ExpensesApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
