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
            InitializeComponent();

            // check if camera is enabled
            checkCamera();
            checkMicrophone();
            checkCalendar();

            // remove status text
            textBoxStatus.Text = "";
        }

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






    }
}
