using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Threading;

namespace FixMy10
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        dataprivacyAppAndDeviceAccess dataprivacyAppAndDeviceAccess = new dataprivacyAppAndDeviceAccess();
        dataprivacyGeneral dataprivacyGeneral = new dataprivacyGeneral();
        helper helper = new helper();


        public MainWindow()
        {

            if (helper.checkWindowsBuildNumber())
            {
                // OS is Windwos 10
                Console.WriteLine("Windows 10 detected");

                // initialize GUI
                InitializeComponent();

                // verify general dataprivacy settings and tick accordingly checkboxes
                checkGeneralDataprivacyAccess();

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
         * Methode setzt den Text der Statuszeile
         */
        public void setStatusUpdateText(String text)
        {
            textBoxStatus.Text = text;
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
         */
        public void clickedButtonrestartAppAsAdmin(object sender, RoutedEventArgs e)
        {
            // restart app as admin in background
            helper.restartAppAsAdmin(sender);
        }


        /*
         * verify general dataprivacy settings and tick accordingly checkboxes
         */
        private void checkGeneralDataprivacyAccess()
        {
            dataprivacyGeneral.verifyAccessAdID();
            dataprivacyGeneral.verifyAccessSmartScreenFilter();
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


        /// <summary>
        /// Tab Datenschutz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /*
         * TabItem Datenschutz Allgemein bekommt Fokus
         */
        private void TabItem_Dataprivacy_General_GotFocus(object sender, RoutedEventArgs e)
        {
            // prüfe derzeitige Einstellungen (User könnte im Hintergrund eine Einstellung geändert haben)
            checkGeneralDataprivacyAccess();
        }



        /*
        * Werbe ID
        */

        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxWerbeID()
        {
            checkBoxAllowUseAdID.IsChecked = true;
        }
        public void uncheckCheckboxWerbeID()
        {
            checkBoxAllowUseAdID.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxAllowUseAdID_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyGeneral.allowAccessAdID();
        }

        private void checkBoxAllowUseAdID_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyGeneral.disallowAccessAdID();
        }


        /*
        * SmartScreen Filter
        */

        // Methoden zum Checkbox an/abhaken
        public void checkCheckboxSmartScreenFilter()
        {
            checkBoxAllowSmartscreen.IsChecked = true;
        }
        public void uncheckCheckboxSmartScreenFilter()
        {
            checkBoxAllowSmartscreen.IsChecked = false;
        }

        // Listener Checkboxen
        private void checkBoxAllowSmartscreen_Checked(object sender, RoutedEventArgs e)
        {
            dataprivacyGeneral.allowSmartScreenFilter();
        }

        private void checkBoxAllowSmartscreen_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyGeneral.disallowSmartScreenFilter();
        }



        /// <summary>
        /// Tab App- Gerätezugriff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /*
         * Methode setzt den Text der Datenschutzerklärungstextbox zurüeck
         */
        private void TabItem_Dataprivacy_AppAndDeviceAcces_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_DefaultText;
        }

        private void TabItem_Dataprivacy_AppAndDeviceAcces_GotFocus(object sender, RoutedEventArgs e)
        {
            // prüfe derzeitige Einstellungen (User könnte im Hintergrund eine Einstellung geändert haben)
            checkAppAndDeviceAccess();
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
            dataprivacyAppAndDeviceAccess.allowAccessAccountInfo();            
        }
        private void checkBoxAccountInfo_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessAccountInfo();
        }
        private void checkBoxAccountInfo_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_BenutzerInfo;
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
            dataprivacyAppAndDeviceAccess.allowAccessPosition();
        }
        private void checkBoxPosition_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessPosition();            
        }
        private void checkBoxPosition_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_Position;
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
            dataprivacyAppAndDeviceAccess.allowAccessCamera();
        }
        private void checkBoxCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessCamera();
        }
        private void checkBoxCamera_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_Kamera;
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
            dataprivacyAppAndDeviceAccess.allowAccessMicrophone();
        }
        private void checkBoxMicrophone_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessMicrophone();
        }
        private void checkBoxMicrophone_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_Mikrofon;
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
            dataprivacyAppAndDeviceAccess.allowAccessCalendar();
        }

        private void checkBoxCalendar_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessCalendar();
        }

        private void checkBoxCalendar_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_Kalender;
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
            dataprivacyAppAndDeviceAccess.allowAccessMessages();
        }

        private void checkBoxMessages_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessMessages();
        }

        private void checkBoxMessages_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_Messages;
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
            dataprivacyAppAndDeviceAccess.allowAccessRadio();
        }

        private void checkBoxRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessRadio();
        }

        private void checkBoxRadio_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_Radio;
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
            dataprivacyAppAndDeviceAccess.allowAccessMoreDevices();
        }

        private void checkBoxMoreDevices_Unchecked(object sender, RoutedEventArgs e)
        {
            dataprivacyAppAndDeviceAccess.disallowAccessMoreDevices();
        }

        private void checkBoxMoreDevices_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = this.appAndDeviceAccessTextBoxExplanation;
            textBox.Text = Properties.Resources.TextBox_TabAppAndDeviceAccess_TextBoxExplanation_MoreDevices;
        }





        /*
         * Test methode um Spracheänderung zu testen
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.changeCultureAndUpdateGUI(new CultureInfo("en-US"));
        }
























    }
}
