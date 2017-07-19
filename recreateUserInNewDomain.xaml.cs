using System;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.IO;
using System.Collections.Generic;


namespace CrowdUserManager
{

    public partial class recreateUserInNewDomain : Window
    {

        string domain;
        string userName;
        string newDomain;
        string firstName;
        string lastName;
        string serverURL;
        string email;
        string[] auth = new string[2];
        string company;
        List<string> userGroupsList= new List<string>();

        public void getCredentials(string dir)

        {
            string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlFile);
            foreach (XmlNode noda in doc.DocumentElement)


            {
                if (noda.Attributes["name"].Value == dir && noda.Attributes["company"].Value == company)
                {
                    serverURL = noda.Attributes["url"].Value + "/rest/usermanagement/1";
                    auth[0] = noda.Attributes["user"].Value;
                    auth[1] = noda.Attributes["password"].Value;

                }
            }
        }

        public void log(string logText)
        {
            Logging make = new Logging();
            make.addLog(logText);

        }


        public void sendPassword()
        {

            try
            {

                string sendPassword = "/user/mail/password?username=";
                string XmlDocument = "";
                getResponse retrive = new getResponse();
                string data = "";
                retrive.POST(serverURL + sendPassword + userName, XmlDocument, auth, out data);


            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }

        }

        public void MessageBox1(string message)
        {

            MessageBox1 MessageBox1 = new MessageBox1();
            MessageBox1.Show(message);

        }

        public void getServerParameters(string companyName)
        {

            try
            {


                string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
                XmlDocument doc = new XmlDocument();

                doc.LoadXml(xmlFile);
                foreach (XmlNode noda in doc.DocumentElement)
                {


                    if (noda.LocalName == "server" && noda.Attributes["company"].Value == companyName && noda.Attributes["name"].Value != currentDomainLabel.Content.ToString())

                        targetDomainComboBox.Items.Add(noda.Attributes["name"].Value);
                }

            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }

            targetDomainComboBox.SelectedIndex=0;

        }


        public recreateUserInNewDomain(string arg0,string arg1, string arg2,string arg3,string arg4,string arg5, List<string> arg6)
        {
            InitializeComponent();
            domain = arg1;
            userName = arg2;
            firstName = arg3;
            lastName = arg4;
            email = arg5;
            userGroupsList = arg6;
            userNameLabel.Content = arg3+" "+arg4;
            currentDomainLabel.Content = domain;
            company = arg0;
            getServerParameters(arg0);
           // ShowDialog();

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void recreateButton_Click(object sender, RoutedEventArgs e)
        {


            newDomain = targetDomainComboBox.Text;
            getCredentials(domain);

            if (userNameLabel.Content.ToString() == "")
            {
                MessageBox1("'User Name' field is empty");
                return;

            }

            DialogBox DialogBox1 = new DialogBox();
            DialogBox1.Show("User '" + userName+ "' will be recreated in " + targetDomainComboBox.Text + " derictory. Would you like to continue?");

            if (DialogBox1.DialogResult == true)
            {

               

                string removeUserURL = "/user?username=" + userName;
                getResponse retrive = new getResponse();
                string data = "";
                
                retrive.DELETE(serverURL + removeUserURL, auth, out data);

                getCredentials(newDomain);
  
                try
                {
                    //create    
                  
                    string pass = "Epam" + DateTime.Now.Millisecond.ToString() + "Epam";            
                    string url = serverURL + "/user";
                    string XmlDocument = "<user name=\"" + userName + "\" expand=\"attributes\"><first-name>" + firstName + "</first-name><last-name>" + lastName + "</last-name><display-name>" + firstName + " " + lastName + "</display-name><email>" + email + "</email><active>true</active><attributes><link rel=\"self\" href=\"/user/attribute?username=" + userName + "\"/></attributes><password><link rel=\"edit\" href=\"/user/password?username=" + userName + "\"/><value>" + pass + "</value></password></user>";
                    retrive = new getResponse();
                    data = "";
                    retrive.POST(url, XmlDocument, auth, out data);
                    //set group

                    foreach(string group in userGroupsList)
                    {
                        string addToGroupURL = "/user/group/direct?username=";
                        XmlDocument = "<group name=\""+group+"\"/>";
                        retrive = new getResponse();
                        data = "";
                        retrive.POST(serverURL + addToGroupURL + userName, XmlDocument, auth, out data);

                    }

                    sendPassword();
                    MessageBox1(userNameLabel.Content+" was successfully recreated in " + targetDomainComboBox.Text +" directory");
                    this.DialogResult = true;
                    log("Recreate - "+ userNameLabel.Content + " was successfully recreated in " + targetDomainComboBox.Text + " directory");                 
                    Close();
                }
 


                catch
                    (Exception ex)
                {
                    MessageBox1(ex.Message);
                }
            }
           
        }
    }
}
