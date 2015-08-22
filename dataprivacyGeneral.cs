using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

namespace FixMy10
{

    /*
     * Klasse um allgemeine Datenschutzeinstellungen zu setzen / lesen
     */
    class dataprivacyGeneral
    {

        errorDialogs errorDialogs = new errorDialogs();

        /*
        * WerbeID
        */

        /*
         * Methode um zu prüfen ob aktuell eine WerbeID verwendet wird
         */
        public void verifyAccessAdID()
        {
            Console.Write("check if ad ID is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo\\";
            String key = "Enabled";

            // get value of registry key
            try
            {
                int regValue = Convert.ToInt32(Registry.GetValue(@path, key, null));
                if (regValue != null)
                {
                    if (regValue == 1)
                    {
                        // tick checkbox
                        ((MainWindow)Application.Current.MainWindow).checkCheckboxWerbeID();
                    }
                    else
                    {
                        // untick checkbox
                        ((MainWindow)Application.Current.MainWindow).uncheckCheckboxWerbeID();
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }



        public void allowAccessAdID()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo\\";
            String key = "Enabled";
            try
            {
                Console.Write("allow access ad ID\n");
                Registry.SetValue(@path, key, 1);

                String Text = Properties.Resources.StatusText_WerbeID_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessAdID()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo\\";
            String key = "Enabled";
            try
            {
                Console.Write("disallow access ad ID\n");
                Registry.SetValue(@path, key, 0);

                String Text = Properties.Resources.StatusText_WerbeID_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }








    }
}
