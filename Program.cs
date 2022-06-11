using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace CashalotHelper
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder (string[] args) => Host
            .CreateDefaultBuilder (args)
            .ConfigureServices(App.ConfigureServices)
        ;
    }
}
