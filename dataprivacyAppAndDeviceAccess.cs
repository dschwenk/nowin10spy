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
     * Klasse um Einstellungen für Geräte- und Appzugriff zu setzen / lesen
     */
    class dataprivacyAppAndDeviceAccess
    {

        errorDialogs errorDialogs = new errorDialogs();


        /*
        * Kontoinformationen
        */

        /*
         * Methode um zu prüfen ob aktuell Zugriff auf die Kontoinformationen gegeben ist
         */
        public void checkAccessAccountInfo()
        {
            Console.Write("check if account info is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{C1D23ACC-752B-43E5-8448-8D0E519CD6D6}\\";
            String key = "Value";
            
            // get value of registry key
            try
            {
                string accountInfoValue = (string)Registry.GetValue(@path, key, null);
                if (accountInfoValue != null)
                {
                    if (accountInfoValue == "Allow")
                    {
                        // tick checkbox
                        ((MainWindow)Application.Current.MainWindow).checkCheckboxBoxAccountInfo();
                    }
                    else
                    {
                        // untick checkbox
                        ((MainWindow)Application.Current.MainWindow).uncheckCheckboxBoxAccountInfo();
                    }
                }
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        /*
         * 
         */
        public void allowAccessAccountInfo()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{C1D23ACC-752B-43E5-8448-8D0E519CD6D6}";
            String key = "Value";
            try
            {
                Console.Write("allow access account info\n");
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffBenutzerinformationen_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }        
        /*
         * 
         */
        public void disallowAccessAccountInfo()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{C1D23ACC-752B-43E5-8448-8D0E519CD6D6}\\";
            String key = "Value";
            try
            {
                Console.Write("disallow access account info\n");
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffBenutzerinformationen_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }



        /*
        * Position 
        */

        /*
         * Methode um zu prüfen ob aktuell Zugriff auf die Position gegeben ist
         */
        public void checkAccessPosition()
        {
            Console.Write("check if position is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}\\";
            String key = "Value";

            string poistionValue = (string)Registry.GetValue(@path, key, null);
            if (poistionValue != null)
            {
                if (poistionValue == "Allow")
                {
                    ((MainWindow)Application.Current.MainWindow).checkCheckboxBoxPosition();
                }
                else
                {
                    ((MainWindow)Application.Current.MainWindow).uncheckCheckboxBoxPosition();
                }
            }
        }
        public void allowAccessPosition()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}";
            String key = "Value";
            try
            {
                Console.Write("allow access position\n");
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffPosition_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessPosition()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}\\";
            String key = "Value";
            try
            {
                Console.Write("disallow access position\n");
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffPosition_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }



        /*
         * Kamera
         */

        /*
         * Methode um zu prüfen ob aktuell Zugriff auf die Kamera gegeben ist
         */
        public void checkAccessCamera()
        {
            Console.Write("check if camera is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E5323777-F976-4f5b-9B55-B94699C46E44}\\";
            String key = "Value";

            string cameraValue = (string)Registry.GetValue(@path, key, null);
            if (cameraValue != null)
            {
                if (cameraValue == "Allow")
                {
                    ((MainWindow)Application.Current.MainWindow).checkCheckboxBoxCamera();
                }
                else
                {
                    ((MainWindow)Application.Current.MainWindow).uncheckCheckboxBoxCamera();
                }
            }
        }
        public void allowAccessCamera()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E5323777-F976-4f5b-9B55-B94699C46E44}";
            String key = "Value";
            try
            {
                Console.Write("allow access camera\n");
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffKamera_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessCamera()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E5323777-F976-4f5b-9B55-B94699C46E44}\\";
            String key = "Value";
            try
            {
                Console.Write("disallow access camera\n");
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffKamera_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }




        /*
         * Mikrofon
         */

        /*
         * Methode um zu prüfen ob aktuell Zugriff auf das Mikrofon gegeben ist
         */
        public void checkAccessMicrophone()
        {
            Console.Write("check if micorphone is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{2EEF81BE-33FA-4800-9670-1CD474972C3F}\\";
            String key = "Value";

            string microphoneValue = (string)Registry.GetValue(@path, key, null);
            if (microphoneValue != null)
            {
                if (microphoneValue == "Allow")
                {
                    ((MainWindow)Application.Current.MainWindow).checkCheckboxBoxMicrophone();
                }
                else
                {
                    ((MainWindow)Application.Current.MainWindow).uncheckCheckboxBoxMicrophone();
                }
            }
        }
        public void allowAccessMicrophone()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{2EEF81BE-33FA-4800-9670-1CD474972C3F}";
            String key = "Value";
            try
            {
                Console.Write("allow access microphone\n");
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffMikrofon_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessMicrophone()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{2EEF81BE-33FA-4800-9670-1CD474972C3F}\\";
            String key = "Value";
            try
            {
                Console.Write("disallow access microphone\n");
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffMikrofon_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }



        /*
         * Kontakte
         */



        /*
         * Kalender
         */

        /*
         * Methode um zu prüfen ob aktuell Zugriff auf den Kalender gegeben ist
         */
        public void checkAccessCalendar()
        {
            Console.Write("check if calendar is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{D89823BA-7180-4B81-B50C-7E471E6121A3}\\";
            String key = "Value";

            string calendarValue = (string)Registry.GetValue(@path, key, null);
            if (calendarValue != null)
            {
                if (calendarValue == "Allow")
                {
                    ((MainWindow)Application.Current.MainWindow).checkCheckboxBoxCalendar();
                }
                else
                {
                    ((MainWindow)Application.Current.MainWindow).uncheckCheckboxBoxCalendar();
                }
            }
        }
        public void allowAccessCalendar()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{D89823BA-7180-4B81-B50C-7E471E6121A3}";
            String key = "Value";
            try
            {
                Console.Write("allow access calendar\n");
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffKalender_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessCalendar()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{D89823BA-7180-4B81-B50C-7E471E6121A3}\\";
            String key = "Value";
            try
            {
                Console.Write("disallow access calendar\n");
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffKalender_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }




        /*
         * Nachrichten 
         */

        /*
         * Methode um zu prüfen ob aktuell Zugriff auf Nachrichten gegeben ist
         */
        public void checkAccessMessages()
        {
            Console.Write("check if messages is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{992AFA70-6F47-4148-B3E9-3003349C1548}\\";
            String key = "Value";

            string messagesValue = (string)Registry.GetValue(@path, key, null);
            if (messagesValue != null)
            {
                if (messagesValue == "Allow")
                {
                    ((MainWindow)Application.Current.MainWindow).checkCheckboxBoxMessages();
                }
                else
                {
                    ((MainWindow)Application.Current.MainWindow).uncheckCheckboxBoxMessages();
                }
            }
        }
        public void allowAccessMessages()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{992AFA70-6F47-4148-B3E9-3003349C1548}";
            String key = "Value";
            try
            {
                Console.Write("allow access messages\n");
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffNachrichten_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessMessages()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{992AFA70-6F47-4148-B3E9-3003349C1548}\\";
            String key = "Value";
            try
            {
                Console.Write("disallow access messages\n");
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffNachrichten_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }


        /*
         * Funkempfang
         */

        /*
         * Methode um zu prüfen ob aktuell Zugriff auf den Funkempfang gegeben ist
         */
        public void checkAccessRadio()
        {
            Console.Write("check if radio is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{A8804298-2D5F-42E3-9531-9C8C39EB29CE}\\";
            String key = "Value";

            string radioValue = (string)Registry.GetValue(@path, key, null);
            if (radioValue != null)
            {
                if (radioValue == "Allow")
                {
                    ((MainWindow)Application.Current.MainWindow).checkCheckboxBoxRadio();
                }
                else
                {
                    ((MainWindow)Application.Current.MainWindow).uncheckCheckboxBoxRadio();
                }
            }
        }

        public void allowAccessRadio()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{A8804298-2D5F-42E3-9531-9C8C39EB29CE}";
            String key = "Value";
            try
            {
                Console.Write("allow access radio\n");
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffFunk_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessRadio()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{A8804298-2D5F-42E3-9531-9C8C39EB29CE}\\";
            String key = "Value";
            try
            {
                Console.Write("disallow access radio\n");
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffFunk_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }




        /*
         * Mit Geräten synchronisieren
         */

        /*
         * Methode um zu prüfen ob aktuell Zugriff auf die synchronisation mehrerer Geräte gegeben ist
         */
        public void checkAccessMoreDevices()
        {
            Console.Write("check if synchronisieren der Geräte is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled\\";
            String key = "Value";

            string moreDevicesValue = (string)Registry.GetValue(@path, key, null);
            if (moreDevicesValue != null)
            {
                if (moreDevicesValue == "Allow")
                {
                    ((MainWindow)Application.Current.MainWindow).checkCheckboxBoxRadio();
                }
                else
                {
                    ((MainWindow)Application.Current.MainWindow).uncheckCheckboxBoxRadio();
                }
            }
        }

        public void allowAccessMoreDevices()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled";
            String key = "Value";
            try
            {
                Console.Write("allow access / sync devices\n");
                Registry.SetValue(@path, key, "Allow");

                String Text = Properties.Resources.StatusText_ZugriffWeitereGeräte_erlaubt;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
        public void disallowAccessMoreDevices()
        {
            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled\\";
            String key = "Value";
            try
            {
                Console.Write("disallow access / sync devices\n");
                Registry.SetValue(@path, key, "Deny");

                String Text = Properties.Resources.StatusText_ZugriffWeitereGeräte_deaktiviert;
                ((MainWindow)Application.Current.MainWindow).setStatusUpdateText(Text);
            }
            catch (Exception e)
            {
                errorDialogs.ShowErrorMessage(e, "Retriving keys of " + path + key);
            }
        }
    }
}
