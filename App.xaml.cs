using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FixMy10
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {

        // dictionary to collect command line arguments
        Dictionary<string, string> arguments = new Dictionary<string, string>();


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            /*
             * are there any arguments (argument(s) are expected when a specific setting needs to be changed as admin)
             * app then is restarted in the background, user must accept UAC, setting will be changed, app will close
             */
            if (e.Args.Length >= 1)
            {
                // http://sa.ndeep.me/post/103/how-to-create-smart-wpf-command-line-arguments

                // access command line arguments
                string[] args = Environment.GetCommandLineArgs();

                // loop through command line arguments
                for (int index = 1; index < args.Length; index += 2)
                {
                    string arg = args[index].Replace("--", "");
                    arguments.Add(arg, args[index + 1]);
                }


                String Text = "";

                // search for specific param
                if (arguments.ContainsKey("message"))
                {
                    Text = arguments["message"];
                }

                MessageBox.Show("message:" + Text);

                // exit app
                System.Environment.Exit(1);
            }



        }

    }
}
