using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Windows;

namespace FixMy10
{
    class tweakWindowsApps
    {

        Pipeline pipeline;
        Collection<PSObject> psresults;


        public tweakWindowsApps()
        {

            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();

            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            runspace.Open();

            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);

            pipeline = runspace.CreatePipeline();

        }



        public void isAppBingWeatherInstalled()
        {

            String myCommand = "Get-AppxPackage 'BrowserChoice'";
            //pipeline.Commands.Add(myCommand);
            pipeline.Commands.AddScript(myCommand);

            // Execute PowerShell script
            psresults = pipeline.Invoke();

            if (psresults.Count == 0)
            {
                // app ist nicht mehr vorhanden
                ((MainWindow)Application.Current.MainWindow).checkCheckboxWindowsAppMicrosoftBingWeather();
            } else {
                ((MainWindow)Application.Current.MainWindow).uncheckCheckboxWindowsAppMicrosoftBingWeather();
            }

        }


        public void removeBingWeater(){

            //Here's how you add a new script with arguments
            // Command myCommand = new Command("Get-AppxPackage 'Microsoft.BingWeather' | Remove-AppxPackage");
            String myCommand = "Get-AppxPackage 'Microsoft.BingWeather' | Remove-AppxPackage";
            //pipeline.Commands.Add(myCommand);
            pipeline.Commands.AddScript(myCommand);

            // Execute PowerShell script
            psresults = pipeline.Invoke();

        }


        public void addBingWeater()
        {

            //Here's how you add a new script with arguments
            // Command myCommand = new Command("Get-AppxPackage 'Microsoft.BingWeather' | Remove-AppxPackage");
            String myCommand = "Add-AppxPackage 'Microsoft.BingWeather'";
            //pipeline.Commands.Add(myCommand);
            pipeline.Commands.AddScript(myCommand);

            // Execute PowerShell script
            psresults = pipeline.Invoke();

        }


    }
}
