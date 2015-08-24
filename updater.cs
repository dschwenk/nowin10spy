using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;



namespace FixMy10
{
    class updater
    {

        public void checkForUpdate(){

            // in newVersion variable we will store the  
            // version info from xml file  
            Version newVersion = null;
            // and in this variable we will put the url we  
            // would like to open so that the user can  
            // download the new version  
            // it can be a homepage or a direct  
            // link to zip/exe file  
            string url = "";
            XmlTextReader reader = null;
            try
            {
                // provide the XmlTextReader with the URL of  
                // our xml document  
                string xmlURL = "http://danielschwenk.de/fixmy10.xml";
                reader = new XmlTextReader(xmlURL);
                // simply (and easily) skip the junk at the beginning  
                reader.MoveToContent();
                // internal - as the XmlTextReader moves only  
                // forward, we save current xml element name  
                // in elementName variable. When we parse a  
                // text node, we refer to elementName to check  
                // what was the node name  
                string elementName = "";
                // we check if the xml starts with a proper  
                // "ourfancyapp" element node  
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "appinfo"))
                {
                    while (reader.Read())
                    {
                        // when we find an element node,  
                        // we remember its name  
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            // for text nodes...  
                            if ((reader.NodeType == XmlNodeType.Text) &&
                                (reader.HasValue))
                            {
                                // we check what the name of the node was  
                                switch (elementName)
                                {
                                    case "version":
                                        // thats why we keep the version info  
                                        // in xxx.xxx.xxx.xxx format  
                                        // the Version class does the  
                                        // parsing for us  
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        url = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (reader != null) reader.Close();
            }



            // get the running version  
            Version curVersion =
             System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            // compare the versions  
            if (curVersion.CompareTo(newVersion) < 0)
            {
                // ask the user if he would like  
                // to download the new version  
                string title = "New version detected";
                string question = "Download the new version?";



                // Displays the MessageBox.
                if (MessageBox.Show(question, title, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    // navigate the default web  
                    // browser to our app  
                    // homepage (the url  
                    // comes from the xml content)  
                    System.Diagnostics.Process.Start(url);
                }
            }
            else
            {
                string title = "No New version detected.";
                string question = "You already have the newest version?";

                // Displays the MessageBox.
                MessageBox.Show(title, question, MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }


    }
}
