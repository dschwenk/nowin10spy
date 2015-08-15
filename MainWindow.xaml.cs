using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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


namespace FixMy10
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        dataprivacyAppAndDeviceAccess dataprivacyAppAndDeviceAccess = new dataprivacyAppAndDeviceAccess();


        public MainWindow()
        {

            if (checkWindowsBuildNumber())
            {
                // OS is Windwos 10
                Console.WriteLine("Windows 10 detected");

                // initialize GUI
                InitializeComponent();

                // verify app- and device access and tick accordingly checkboxes
                checkAppAndDeviceAccess();


                // remove status text in "taskbar"
                textBoxStatus.Text = "";
            }
            else
            {
                // NO Windwos 10
                Console.WriteLine("unsupported Windows detected");

                osVersionNotSupported();
            }
        }


        /*
         * Method to inform user via dialog that OS version is not supported / Windows 10 is required
         */ 
        private void osVersionNotSupported()
        {
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


        /*
         * Methode startet FixMy10 in neuem Prozess als Administartor und übergibt Parameter mit Änderungswunsch
         * 
         * http://stackoverflow.com/questions/16926232/run-process-as-administrator-from-a-non-admin-application
         */
        private void restartAppAsAdmin(object sender, RoutedEventArgs e)
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
                    MessageBox.Show("Why you no select Yes?");
                else
                    throw;
            }
        }


        /*
         * verify app- and device access and tick accordingly checkboxes
         */
        private void checkAppAndDeviceAccess()
        {
            dataprivacyAppAndDeviceAccess.checkAccessAccountInfo();
            dataprivacyAppAndDeviceAccess.checkAccessPosition();
            dataprivacyAppAndDeviceAccess.checkAccessCamera();
            dataprivacyAppAndDeviceAccess.checkAccessMicrophone();
            // checkContacts();
            dataprivacyAppAndDeviceAccess.checkAccessCalendar();
            dataprivacyAppAndDeviceAccess.checkAccessMessages();
            dataprivacyAppAndDeviceAccess.checkAccessRadio();
            dataprivacyAppAndDeviceAccess.checkAccessMoreDevices();
        }


        private bool checkWindowsBuildNumber()
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
         * Methode setzt den Text der Datenschutzerklärungstextbox zurüeck
         */
        private void TabItem_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Hier finden Sie Erklärungen und ergänzende Informationen zu den einzelnen Einstellungen.";
        }


        /*
         * Methode setzt den Text der Datenschutzerklärungstextbox
         */
        public void setDataprivacyTextboxText(String text)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = text;
        }


        /*
        * Kontoinformationen
        */
        
        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxBoxAccountInfo()
        {
            appAndDeviceAccessCheckBoxAccountInfo.IsChecked = true;
        }
        public void uncheckCheckboxBoxAccountInfo()
        {
            appAndDeviceAccessCheckBoxAccountInfo.IsChecked = false;
        }     
        
        // Listener Checkboxen
        private void checkBoxAccountInfo_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessAccountInfo();
        }
        private void checkBoxAccountInfo_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.allowAccessAccountInfo();
        }
        private void checkBoxAccountInfo_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Apps den Zugriff auf meinen Namen, mein Bild und andere Kontoinfos erlauben";
        }




        /*
        * Position 
        */

        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxBoxPosition()
        {
            appAndDeviceAccessCheckBoxPosition.IsChecked = true;
        }
        public void uncheckCheckboxBoxPosition()
        {
            appAndDeviceAccessCheckBoxPosition.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxPosition_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessPosition();
        }
        private void checkBoxPosition_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.allowAccessPosition();
        }
        private void checkBoxPosition_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Wenn Positionsdienste für dieses Konto aktiviert sind, können autorisierte Apps und Dienste Positionen und Positionsverlauf abfragen.";
        }



        /*
         * Kamera
         */
        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxBoxCamera()
        {
            appAndDeviceAccessCheckBoxCamera.IsChecked = true;
        }
        public void uncheckCheckboxBoxCamera()
        {
            appAndDeviceAccessCheckBoxCamera.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxCamera_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessCamera();
        }
        private void checkBoxCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.allowAccessCamera();
        }
        private void checkBoxCamera_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Apps die Verwendung meiner Kamera erlauben.\n\nEinige Apps benötige Zugriff auf Ihre Kamera, damit Sie bestimmungsgemäß funktionieren. Wenn Sie den Zugriff deaktivieren, schränken Sie möglicherweise deren Funktionsumfang ein.\n\nWhat is Camera and how do camera settings work?\n\nMany apps and services request and use your device’s camera(s) to provide you with convenient services, such as Skype video calls or taking a photo to add to your favorite social site. Windows camera settings give you control over which apps can use your camera(s).\n\nHow do I know when the camera is on?\n\nIf your system comes with a camera light, the light will turn on when the camera is in use. If your system doesn’t have a camera light, a notification will appear letting you know when the camera turns on or off.";
        }



        /*
         * Mikrofon
         */
        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxBoxMicrophone()
        {
            appAndDeviceAccessCheckBoxMicrophone.IsChecked = true;
        }
        public void uncheckCheckboxBoxMicrophone()
        {
            appAndDeviceAccessCheckBoxMicrophone.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxMicrophone_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessMicrophone();
        }
        private void checkBoxMicrophone_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.allowAccessMicrophone();
        }
        private void checkBoxMicrophone_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Apps die Verwendung meines Mikrofons erlauben.\n\nEinige Apps benötige Zugriff auf Ihr Mikrofon, damit Sie bestimmungsgemäß funktionieren. Wenn Sie den Zugriff deaktivieren, schränken Sie möglicherweise deren Funktionsumfang ein.";
        }


        /*
         * Kontakte
         */


        /*
         * Kalender
         */
        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxBoxCalendar()
        {
            appAndDeviceAccessCheckBoxCalendar.IsChecked = true;
        }
        public void uncheckCheckboxBoxCalendar()
        {
            appAndDeviceAccessCheckBoxCalendar.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxCalendar_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessCalendar();
        }

        private void checkBoxCalendar_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.allowAccessCalendar();
        }

        private void checkBoxCalendar_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Apps Zugriff auf meinen Kalender erlauben.\n\nEinige Apps benötige Zugriff auf Ihren Kalender, damit Sie bestimmungsgemäß funktionieren. Wenn Sie den Zugriff deaktivieren, schränken Sie möglicherweise deren Funktionsumfang ein.";
        }




        /*
         * Nachrichten 
         */
        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxBoxMessages()
        {
            appAndDeviceAccessCheckBoxMessages.IsChecked = true;
        }
        public void uncheckCheckboxBoxMessages()
        {
            appAndDeviceAccessCheckBoxMessages.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxMessages_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessMessages();
        }

        private void checkBoxMessages_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.allowAccessMessages();
        }

        private void checkBoxMessages_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Apps das Lesen oder Senden von Nachrichten (SMS oder MMS) erlauben.";
        }



        /*
         * Funkempfang
         */
        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxBoxRadio()
        {
            appAndDeviceAccessCheckBoxRadio.IsChecked = true;
        }
        public void uncheckCheckboxBoxRadio()
        {
            appAndDeviceAccessCheckBoxRadio.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxRadio_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessRadio();
        }

        private void checkBoxRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.allowAccessRadio();
        }

        private void checkBoxRadio_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Einige Apps verwenden auf dem Gerät Funkttechnik wie Bluetooth für den Empfang und das Senden von Daten. In einigen Fällen müssen Apps den Funkempfang aktivieren und deaktiveren um optimal zu funktionieren.";
        }




        /*
         * Mit Geräten synchronisieren
         */
        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxBoxMoreDevices()
        {
            appAndDeviceAccessCheckBoxMoreDevices.IsChecked = true;
        }
        public void uncheckCheckboxBoxMoreDevices()
        {
            appAndDeviceAccessCheckBoxMoreDevices.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxMoreDevices_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessMoreDevices();
        }

        private void checkBoxMoreDevices_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.allowAccessMoreDevices();
        }

        private void checkBoxMoreDevices_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = "Erlauben Sie Apps, automatisch Informationen mit Drahtlosgeräten auszutauschen und zu synchronisieren, die nicht explizit mit Ihrem PC, Tablet oder Handy gekoppelt sind.";
        }

















    }
}
