using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;


namespace NoSpy_1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            if (checkWindowsBuildNumber())
            {
                // OS is Windwos 10
                Console.WriteLine("Windows 10 detected");

                // initialize GUI
                InitializeComponent();

                // check if camera is enabled
                checkCamera();
                checkMicrophone();
                checkCalendar();

                // remove status text
                textBoxStatus.Text = "";
            }
            else
            {
                // NO Windwos 10
                Console.WriteLine("unsupported Windows detected");

                // Configure the message box to be displayed
                string messageBoxText = "Your OS version is not supported, Windows 10 or higher is required.";
                string caption = "NoWin10Spy requires Windows 10";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                // Display message box
                MessageBox.Show(messageBoxText, caption, button, icon);

                // exit app
                System.Environment.Exit(1);
            }
        }


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




        /*
         * Kamera
         */
        private void checkCamera()
        {
            Console.Write("check if camera is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E5323777-F976-4f5b-9B55-B94699C46E44}\\";
            String key = "Value";

            string cameraValue = (string)Registry.GetValue(@path, key, null);
            if (cameraValue != null)
            {
                if (cameraValue == "Allow")
                {
                    checkBoxCamera.IsChecked = true;
                }
                else
                {
                    checkBoxCamera.IsChecked = false;
                }
            }
        }

        private void checkBoxCamera_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box is checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E5323777-F976-4f5b-9B55-B94699C46E44}\\";
                String key = "Value";
                Registry.SetValue(@path, key, "Allow");

                textBoxStatus.Text = "Zugriff auf Kamera erlaubt";
            }
            catch
            {

            }
        }

        private void checkBoxCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box is NOT checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E5323777-F976-4f5b-9B55-B94699C46E44}";
                String key = "Value";
                Registry.SetValue(@path, key, "Deny");

                textBoxStatus.Text = "Zugriff auf Kamera deaktivert";
            }
            catch
            {

            }
        }

        private void checkBoxCamera_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.textBoxExplanationDataPrivacy;
            // textBox.Text = "Kamera Text";
            textBox.Text = "Apps die Verwendung meiner Kamera erlauben.\n\nEinige Apps benötige Zugriff auf Ihre Kamera, damit Sie bestimmungsgemäß funktionieren. Wenn Sie den Zugriff deaktivieren, schränken Sie möglicherweise deren Funktionsumfang ein.\n\nWhat is Camera and how do camera settings work?\n\nMany apps and services request and use your device’s camera(s) to provide you with convenient services, such as Skype video calls or taking a photo to add to your favorite social site. Windows camera settings give you control over which apps can use your camera(s).\n\nHow do I know when the camera is on?\n\nIf your system comes with a camera light, the light will turn on when the camera is in use. If your system doesn’t have a camera light, a notification will appear letting you know when the camera turns on or off.";
        }


        /*
         * Mikrofon
         */

        private void checkMicrophone()
        {
            Console.Write("check if micorphone is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{2EEF81BE-33FA-4800-9670-1CD474972C3F}\\";
            String key = "Value";

            string microphoneValue = (string)Registry.GetValue(@path, key, null);
            if (microphoneValue != null)
            {
                if (microphoneValue == "Allow")
                {
                    checkBoxMicrophone.IsChecked = true;
                }
                else
                {
                    checkBoxMicrophone.IsChecked = false;
                }
            }
        }

        private void checkBoxMicrophone_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box is checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{2EEF81BE-33FA-4800-9670-1CD474972C3F}\\";
                String key = "Value";
                Registry.SetValue(@path, key, "Allow");

                textBoxStatus.Text = "Zugriff auf Mikrofon erlaubt";
            }
            catch
            {

            }
        }


        private void checkBoxMicrophone_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box is NOT checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{2EEF81BE-33FA-4800-9670-1CD474972C3F}";
                String key = "Value";
                Registry.SetValue(@path, key, "Deny");

                textBoxStatus.Text = "Zugriff auf Mikrofon deaktiviert";
            }
            catch
            {

            }
        }

        private void checkBoxMicrophone_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.textBoxExplanationDataPrivacy;
            textBox.Text = "Apps die Verwendung meines Mikrofons erlauben.\n\nEinige Apps benötige Zugriff auf Ihr Mikrofon, damit Sie bestimmungsgemäß funktionieren. Wenn Sie den Zugriff deaktivieren, schränken Sie möglicherweise deren Funktionsumfang ein.";
        }



        /*
         * Kalender
         */

        private void checkCalendar()
        {
            Console.Write("check if calendar is enabled\n");

            String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{D89823BA-7180-4B81-B50C-7E471E6121A3}\\";
            String key = "Value";

            string calendarValue = (string)Registry.GetValue(@path, key, null);
            if (calendarValue != null)
            {
                if (calendarValue == "Allow")
                {
                    checkBoxCalendar.IsChecked = true;
                }
                else
                {
                    checkBoxCalendar.IsChecked = false;
                }
            }
        }

        private void checkBoxCalendar_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box is checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{D89823BA-7180-4B81-B50C-7E471E6121A3}\\";
                String key = "Value";
                Registry.SetValue(@path, key, "Allow");

                textBoxStatus.Text = "Zugriff auf Kalender deaktiviert";
            }
            catch
            {

            }
        }

        private void checkBoxCalendar_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box is NOT checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{D89823BA-7180-4B81-B50C-7E471E6121A3}";
                String key = "Value";
                Registry.SetValue(@path, key, "Deny");

                textBoxStatus.Text = "Zugriff auf Kalender erlaubt";
            }
            catch
            {

            }
        }

        private void checkBoxCalendar_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.textBoxExplanationDataPrivacy;
            textBox.Text = "Apps Zugriff auf meinen Kalender erlauben.\n\nEinige Apps benötige Zugriff auf Ihren Kalender, damit Sie bestimmungsgemäß funktionieren. Wenn Sie den Zugriff deaktivieren, schränken Sie möglicherweise deren Funktionsumfang ein.";
        }


        /*
         * Position 
         */
        private void checkBoxPosition_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box position is checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}\\";
                String key = "Value";
                Registry.SetValue(@path, key, "Allow");

                textBoxStatus.Text = "Zugriff auf Position deaktiviert";
            }
            catch
            {

            }
        }

        private void checkBoxPosition_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box is NOT checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}";
                String key = "Value";
                Registry.SetValue(@path, key, "Deny");

                textBoxStatus.Text = "Zugriff auf Position erlaubt";
            }
            catch
            {

            }
        }

        private void checkBoxPosition_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.textBoxExplanationDataPrivacy;
            textBox.Text = "Ist diese Einstellung aktiviert, kann jeder, der sich bei diesem Gerät anmeldet seine eigenen Positionseinstellungen ändern. Ist die Einstellung deaktiviert, die die Positionsangabe für alle Benuter, die sich anmelden, deaktiviert.\n\nWenn Positionsdienste für dieses Konto aktiviert sind, können autorisierte Apps und Dienste Positionen und Positionsverlauf abfragen.";
        }

        /*
         * Nachrichten 
         */
        private void checkBoxMessages_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box nachrichten is checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{992AFA70-6F47-4148-B3E9-3003349C1548}\\";
                String key = "Value";
                Registry.SetValue(@path, key, "Allow");

                textBoxStatus.Text = "Zugriff auf Nachrichten deaktiviert";
            }
            catch
            {

            }
        }

        private void checkBoxMessages_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("unchecked nachrichten\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{992AFA70-6F47-4148-B3E9-3003349C1548}";
                String key = "Value";
                Registry.SetValue(@path, key, "Deny");

                textBoxStatus.Text = "Zugriff auf Nachrichten erlaubt";
            }
            catch
            {

            }
        }

        private void checkBoxMessages_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.textBoxExplanationDataPrivacy;
            textBox.Text = "Apps das Lesen oder Senden von Nachrichten (SMS oder MMS) erlauben.";
        }

        /*
         * Funkempfang
         */
        private void checkBoxRadio_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("check box radio is checked\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{A8804298-2D5F-42E3-9531-9C8C39EB29CE}\\";
                String key = "Value";
                Registry.SetValue(@path, key, "Allow");

                textBoxStatus.Text = "Zugriff auf Funkempfang deaktiviert";
            }
            catch
            {

            }
        }

        private void checkBoxRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write("unchecked nachrichten\n");
                String path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{A8804298-2D5F-42E3-9531-9C8C39EB29CE}";
                String key = "Value";
                Registry.SetValue(@path, key, "Deny");

                textBoxStatus.Text = "Zugriff auf Funkempfang erlaubt";
            }
            catch
            {

            }
        }

        private void checkBoxRadio_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.textBoxExplanationDataPrivacy;
            textBox.Text = "Einige Apps verwenden auf dem Gerät Funkttechnik wie Bluetooth für den Empfang und das Senden von Daten. In einigen Fällen müssen Apps den Funkempfang aktivieren und deaktiveren um optimal zu funktionieren.";
        }






    }
}
