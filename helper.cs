using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;



namespace FixMy10
{
    class helper
    {



        public bool checkWindowsBuildNumber()
        {
            // Windows Operating System Versions
            // https://msdn.microsoft.com/en-us/library/windows/desktop/ms724832(v=vs.85).aspx

            /*
            Console.WriteLine("OSVersion VersionString: {0}", Environment.OSVersion.VersionString);


            Console.WriteLine("OSVersion: {0}", Environment.OSVersion.Version.ToString());

            int major = Environment.OSVersion.Version.Major;
            */
            return true;
        }



        public void setAppLanguage()
        {
            // get operating system language
            // http://stackoverflow.com/questions/5710127/get-operating-system-language-in-c-sharp

            // Language Codes
            // https://msdn.microsoft.com/de-de/library/ms533052(v=vs.85).aspx

            CultureInfo ci = CultureInfo.CurrentUICulture;
            Console.WriteLine("CultureInfo: " + ci.Name);
            if (ci.Name.Contains("de")) // de-at, de-li, de-ch, de-lu
            {
                FixMy10.Properties.Resources.Culture = new CultureInfo("de-DE");
            }
            else
            {
                FixMy10.Properties.Resources.Culture = new CultureInfo("en-US");
            }
        }



        /*
         * Methode startet FixMy10 in neuem Prozess als Administartor und übergibt Parameter mit Änderungswunsch
         * 
         * http://stackoverflow.com/questions/16926232/run-process-as-administrator-from-a-non-admin-application
         */
        public void restartAppAsAdmin(object sender)
        {
            const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.

            // get process path of current running FixMy10
            // http://stackoverflow.com/questions/5497064/c-how-to-get-the-full-path-of-running-process
            var p = Process.GetCurrentProcess();
            String currentProcessPath = p.MainModule.FileName;

            // ProcessStartInfo info = new ProcessStartInfo(@"C:\Users\dschwenk\Documents\Visual Studio 2013\Projects\NoSpy_1\NoSpy_1\bin\Release\FixMy10.exe");
            ProcessStartInfo info = new ProcessStartInfo(@currentProcessPath);
            info.UseShellExecute = true;
            info.Verb = "runas";


            // button passes information via CommandParameter
            var button = sender as Button;
            String code = button.CommandParameter.ToString();

            String processArgument = "";

            // verify which CommandParamater was sent / which checkbox/button was clicked
            if (code.ToString().Equals("disableXY"))
            {
                processArgument = "--message \"this is my message\"";
            }

            // pass argument to new process
            info.Arguments = processArgument;
            try
            {
                Process.Start(info);
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_CANCELLED)
                    Console.WriteLine("Why you no select Yes?");
                else
                    throw;
            }
        }




    }
}
