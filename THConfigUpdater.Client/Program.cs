using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using THConfigUpdater.Client.Configs;
using THConfigUpdater.Client.Core.FileBased;

namespace THConfigUpdater.Client
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        //private static IHostBuilder CreateHostBuilder()
        //{
        //    return Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSingleton<FileBasedConfigService>(new FileBasedConfigService(GlobalConfig.ServerBaseUrl));

        //            services.AddScoped<MainForm>();
        //        });
        //}
    }
}
