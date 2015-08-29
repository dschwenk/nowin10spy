using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixMy10
{
    class systemInformation
    {



        private bool Is64BitOperatingSystem;




        public systemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("OSVersion: {0}", Environment.OSVersion.ToString());
            Console.WriteLine("OSVersion Platform: {0}", Environment.OSVersion.Platform.ToString());
            Console.WriteLine("OSVersion Service Pack: {0}", Environment.OSVersion.ServicePack.ToString());
            
            Console.WriteLine("Machine Name: {0}", Environment.MachineName.ToString());

            Console.WriteLine("Is64BitOperatingSystem: {0}", Environment.Is64BitOperatingSystem.ToString());
            Is64BitOperatingSystem = Environment.Is64BitOperatingSystem;

            Console.WriteLine("CurrentDirectory: {0}", Environment.CurrentDirectory.ToString());

            Console.WriteLine("UserName: {0}", Environment.UserName.ToString());
            Console.WriteLine("UserDomainName: {0}", Environment.UserDomainName.ToString());

            Console.WriteLine();
        }

    }
}
