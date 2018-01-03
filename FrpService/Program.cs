using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FrpService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0].ToLower())
                {
                    case "/i":
                    case "-i":
                        AssemblyInstall(true);
                        return;
                    case "/u":
                    case "-u":
                        AssemblyInstall(false);
                        return;
                }
            }
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MainService(args)
            };

            ServiceBase.Run(ServicesToRun);

            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new MainService(args)
            //};
            //ServiceBase.Run(ServicesToRun);
        }



        private static void AssemblyInstall(bool isInstall)
        {
            try
            {
                string[] cmdline = { };
                IDictionary hash = new Hashtable();
                string serviceFileName = Assembly.GetExecutingAssembly().Location;
                AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);
                if (isInstall)
                    assemblyInstaller.Install(hash);
                else
                    assemblyInstaller.Uninstall(hash);

                assemblyInstaller.Commit(hash);
            }
            catch
            {

            }

        }
    }
}
