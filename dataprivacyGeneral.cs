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




        /*
        * SmartScreen Filter
        */

        /*
         * Methode um zu prüfen ob aktuell der SmartScreen Filter verwendet wird
         */
        public void verifyAccessSmartScreenFilter()
        {
            Console.Write("check if SmartScreen filter is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppHost\\";
            String key = "EnableWebContentEvaluation";

            // get value of registry key
            try
            {
                int regValue = Convert.ToInt32(Registry.GetValue(@path, key, null));
                if (regValue != null)
                {
                    if (regValue == 1)
                    {
                        // tick checkbox
                        ((MainWindow)Application.Current.MainWindow).checkCheckboxSmartScreenFilter();
                    }
                    else
                    {
                        // untick checkbox
                        ((MainWindow)Application.Current.MainWindow).uncheckCheckboxSmartScreenFilter();
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }



        public void allowSmartScreenFilter()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppHost\\";
            String key = "EnableWebContentEvaluation";
            try
            {
                Console.Write("allow use SmartScreen filter\n");
                Registry.SetValue(@path, key, 1);

                String Text = Properties.Resources.StatusText_SmartScreenFilter_aktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowSmartScreenFilter()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppHost\\";
            String key = "EnableWebContentEvaluation";
            try
            {
                Console.Write("disallow  use SmartScreen filter\n");
                Registry.SetValue(@path, key, 0);

                String Text = Properties.Resources.StatusText_SmartScreenFilter_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }





        /*
        * Informationen zum Schreibverhalten
        */

        /*
         * Methode um zu prüfen ob aktuell Informationen über das Schreibverhalten an Microsoft gesendet werden
         */
        public void verifyAccessSendWritingInfo()
        {
            Console.Write("check if 'send writing info' is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Input\\TIPC\\";
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
                        ((MainWindow)Application.Current.MainWindow).checkCheckboxSendWritingInfo();
                    }
                    else
                    {
                        // untick checkbox
                        ((MainWindow)Application.Current.MainWindow).uncheckCheckboxSendWritingInfo();
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }



        public void allowSendWritingInfo()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Input\\TIPC\\";
            String key = "Enabled";
            try
            {
                Console.Write("allow send writing info\n");
                Registry.SetValue(@path, key, 1);

                String Text = Properties.Resources.StatusText_Schreibverhalten_aktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowSendWritingInfo()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Input\\TIPC\\";
            String key = "Enabled";
            try
            {
                Console.Write("disallow send writing info\n");
                Registry.SetValue(@path, key, 0);

                String Text = Properties.Resources.StatusText_Schreibverhalten_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }





        /*
        * Zugriff auf Sprachliste
        */

        /*
         * Methode um zu prüfen ob Zugriff auf die Sprachliste gestattet ist
         */
        public void verifyAccessSpeechList()
        {
            Console.Write("check if 'access on speech list' is enabled\n");

            String path = "HKEY_CURRENT_USER\\Control Panel\\International\\User Profile\\";
            String key = "HttpAcceptLanguageOptOut";

            // get value of registry key
            try
            {
                int regValue = Convert.ToInt32(Registry.GetValue(@path, key, null));
                if (regValue != null)
                {
                    if (regValue == 0)
                    {
                        // tick checkbox
                        ((MainWindow)Application.Current.MainWindow).checkCheckboxAllowAccessSpeechList();
                    }
                    else
                    {
                        // untick checkbox
                        ((MainWindow)Application.Current.MainWindow).uncheckCheckboxAllowAccessSpeechList();
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }



        public void allowAccessSpeechList()
        {
            String path = "HKEY_CURRENT_USER\\Control Panel\\International\\User Profile\\";
            String key = "HttpAcceptLanguageOptOut";
            try
            {
                Console.Write("allow 'access on speech list'\n");
                Registry.SetValue(@path, key, 0);

                String Text = Properties.Resources.StatusText_ZugriffAufsprachliste_aktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessSpeechList()
        {
            String path = "HKEY_CURRENT_USER\\Control Panel\\International\\User Profile\\";
            String key = "HttpAcceptLanguageOptOut";
            try
            {
                Console.Write("disallow 'access on speech list'\n");
                Registry.SetValue(@path, key, 1);

                String Text = Properties.Resources.StatusText_ZugriffAufsprachliste_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }







        /*
        * Mich kennenlernen - Spracherkennung, Freihand und Eingabe
        */

        /*
         * Methode um zu prüfen ob Zugriff auf die Sprachliste gestattet ist
         */
        public void verifyAccessGetToKnowMe()
        {
            if (verifyAccessGetToKnowMe1() && verifyAccessGetToKnowMe2() && verifyAccessGetToKnowMe3() && verifyAccessGetToKnowMe4() && verifyAccessGetToKnowMe5())
            {
                // tick checkbox
                ((MainWindow)Application.Current.MainWindow).checkCheckboxcheckBoxGetToKnowMe();
            }
            else
            {
                // untick checkbox
                ((MainWindow)Application.Current.MainWindow).uncheckCheckboxcheckBoxGetToKnowMe();
            }
        }



        private bool verifyAccessGetToKnowMe1()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Personalization\\Settings\\";
            String key = "AcceptedPrivacyPolicy";

            // get value of registry key
            try
            {
                int regValue = Convert.ToInt32(Registry.GetValue(@path, key, null));
                if (regValue != null)
                {
                    if (regValue == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
            return false;
        }

        private bool verifyAccessGetToKnowMe2()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\InputPersonalization\\";
            String key = "RestrictImplicitTextCollection";

            // get value of registry key
            try
            {
                int regValue = Convert.ToInt32(Registry.GetValue(@path, key, null));
                if (regValue != null)
                {
                    if (regValue == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
            return false;
        }

        private bool verifyAccessGetToKnowMe3()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Personalization\\Settings\\";
            String key = "RestrictImplicitInkCollection";

            // get value of registry key
            try
            {
                int regValue = Convert.ToInt32(Registry.GetValue(@path, key, null));
                if (regValue != null)
                {
                    if (regValue == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
            return false;
        }

        private bool verifyAccessGetToKnowMe4()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore\\";
            String key = "HarvestContacts";

            // get value of registry key
            try
            {
                int regValue = Convert.ToInt32(Registry.GetValue(@path, key, null));
                if (regValue != null)
                {
                    if (regValue == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
            return false;
        }

        private bool verifyAccessGetToKnowMe5()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled\\";
            String key = "Value";

            try
            {
                string regValue = (string)Registry.GetValue(@path, key, null);
                if (regValue != null)
                {
                    if (regValue == "Allow")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
            return false;
        }






        public void allowGetToKnowMe()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Personalization\\Settings\\";
            String key = "AcceptedPrivacyPolicy";
            Console.Write("disallow get to know me\n");
            try
            {
                Registry.SetValue(@path, key, 1);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }

            path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\InputPersonalization\\";
            key = "RestrictImplicitTextCollection";
            try
            {
                Registry.SetValue(@path, key, 0);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }

            path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Personalization\\Settings\\";
            key = "RestrictImplicitInkCollection";
            try
            {
                Registry.SetValue(@path, key, 0);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }

            path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore\\";
            key = "HarvestContacts";
            try
            {
                Registry.SetValue(@path, key, 1);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
            path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled\\";
            key = "Value";
            try
            {
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffMichKennenlernen_aktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowGetToKnowMe()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Personalization\\Settings\\";
            String key = "AcceptedPrivacyPolicy";
            Console.Write("disallow get to know me\n");
            try
            {
                Registry.SetValue(@path, key, 0);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }

            path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\InputPersonalization\\";
            key = "RestrictImplicitTextCollection";
            try
            {
                Registry.SetValue(@path, key, 1);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }

            path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Personalization\\Settings\\";
            key = "RestrictImplicitInkCollection";
            try
            {
                Registry.SetValue(@path, key, 1);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }

            path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore\\";
            key = "HarvestContacts";
            try
            {
                Registry.SetValue(@path, key, 0);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
            path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled\\";
            key = "Value";
            try
            {
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffMichKennenlernen_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }


    }
}
