using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;

using System.Xml;

using System.IO;



namespace CrowdUserManager
{
    /// <summary>
    /// Interaction logic for groupCopyWindow.xaml
    /// </summary>
    public partial class groupCopyWindow : Window
    {
        
        public void MessageBox1(string message)
        {

            MessageBox1 MessageBox1 = new MessageBox1();
            MessageBox1.Show(message);

        }


        List<string> directories = new List<string>();
        List<string> foundUsers = new List<string>();
        string userUnderProcess = "";
        string company = "";
        string serverURL = "";
        string[] auth = new string[2];
        string[] auth0 = new string[2];
        string userName ="";
        string notFoundXML = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><users expand=\"user\"/>";





        public void log(string logText)
        {
            Logging make = new Logging();
            make.addLog(logText);

        }

        public void getCredentials(string directory)

        {
            string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlFile);
            foreach (XmlNode noda in doc.DocumentElement)


            {
                if (noda.Attributes["name"].Value == directory && noda.Attributes["company"].Value == company)
                {
                    serverURL = noda.Attributes["url"].Value + "/rest/usermanagement/1";
                    auth[0] = noda.Attributes["user"].Value;
                    auth[1] = noda.Attributes["password"].Value;

                }
            }
        }


        public void getUserGroups(string user)

        {
            foreach (var directory in directories)
            {

                if (listBoxSearchUser.Items.Count != 0)
                {
                    return;
                }

                getCredentials(directory);

                try
                {
                   
                    listBoxSearchUser.Items.Clear();
                    string urlUserGroupSearch = serverURL + "/user/group/direct?username=" + user;
                    getResponse retrive = new getResponse();
                    string groupList = "";
                    retrive.GET(urlUserGroupSearch, auth, out groupList);
                  
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(groupList);
                    foreach (XmlNode noda in doc.DocumentElement)
                    {

                        if (noda.LocalName == "group")
                            listBoxSearchUser.Items.Add(noda.Attributes["name"].Value);
                    }
                }


                catch

                    (Exception ex)
                {
                    MessageBox1(ex.Message);
                }

            }
        }


        public void getServerParameters(string companyName,string procUserName, string procFirstName, string procLastName, List<string> userGroupsList,string[] procAuth)
        {
            InitializeComponent();
            auth0 = procAuth;
            userUnderProcess = procUserName;
            company = companyName;
            currentUser.Content = procFirstName + " " + procLastName;
            foreach (var item in userGroupsList)
            {
                listBox1.Items.Add(item.ToString());
            }

            try
            {

                
                string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
                XmlDocument doc = new XmlDocument();

                doc.LoadXml(xmlFile);
                foreach (XmlNode noda in doc.DocumentElement)
                {


                    if (noda.LocalName == "server" && noda.Attributes["company"].Value == company)

                        directories.Add(noda.Attributes["name"].Value);
                }

            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }

        }





        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var directory in directories)
            {

                getCredentials(directory);

                searchTextBox.Text = searchTextBox.Text.TrimStart(' ').TrimEnd(' ');

                if (searchTextBox.Text.Contains(" "))
                {
                    string url = serverURL + "/search?entity-type=user&restriction=displayName%20=%20%22*" + searchTextBox.Text + "*%22";
                    getResponse retrive = new getResponse();
                    string data = "";
                    retrive.GET(url, auth, out data);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(data);
                    foreach (XmlNode noda in doc.DocumentElement)
                    {
                        if (noda.LocalName == "user")
                        {

                            
                            userName = noda.Attributes["name"].Value;

                            foundUsers.Add(userName);

                        }
                    }

                    

                }

                if (searchTextBox.Text.Contains("@"))
                {
                    
                    string url = serverURL + "/search?entity-type=user&restriction=email%20=%20%22*" + searchTextBox.Text + "*%22";
                    getResponse retrive = new getResponse();
                    string data = "";
                    retrive.GET(url, auth, out data);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(data);
                    foreach (XmlNode noda in doc.DocumentElement)
                    {
                        if (noda.LocalName == "user")
                        {


                            userName = noda.Attributes["name"].Value;

                            foundUsers.Add(userName);

                        }
                    }

                    searchTextBox.Text.Substring(0, searchTextBox.Text.IndexOf("@"));

                     url = serverURL + "/search?entity-type=user&restriction=name%20=%20%22*" + searchTextBox.Text + "*%22";
                    retrive = new getResponse();
                    data = "";
                    retrive.GET(url, auth, out data);

                    doc = new XmlDocument();
                    doc.LoadXml(data);
                    foreach (XmlNode noda in doc.DocumentElement)
                    {
                        if (noda.LocalName == "user")
                        {


                            userName = noda.Attributes["name"].Value;

                            foundUsers.Add(userName);

                        }
                    }

                }

                else 
                {
                    string url = serverURL + "/search?entity-type=user&restriction=name%20=%20%22*" + searchTextBox.Text + "*%22";
                    getResponse retrive = new getResponse();
                    string data = "";
                    retrive.GET(url, auth, out data);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(data);
                    foreach (XmlNode noda in doc.DocumentElement)
                    {
                        if (noda.LocalName == "user")
                        {


                            userName = noda.Attributes["name"].Value;

                            foundUsers.Add(userName);

                        }
                    }



                }

               
            
                

            }
            if (foundUsers.Count == 0)
            {
                MessageBox1("No users found");
                return;
            }

            getUserGroups(foundUsers.Last());

        }

        private void buttonEqualize_Click(object sender, RoutedEventArgs e)
        {


        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
         
            Close();
        }

        private void copyGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> diffGroups = new List<string>();
            string XmlDocument = "";
            foreach (string group in listBoxSearchUser.Items)
            {

                if (listBox1.Items.Contains(group)==false)
                {
                    diffGroups.Add(group);

                } 

            }

             

        

                if (diffGroups.Count != 0)
                {
          DialogBox DialogBox1 = new DialogBox();
          DialogBox1.Show("Group/s will be added. Would you like to continue?");
          if (DialogBox1.DialogResult == true)

                {

                    foreach (string group in diffGroups)
                    {


                        string url = serverURL + "/group?groupname=" + group;
                        getResponse retrive = new getResponse();
                        string data = "";
                        retrive.GET(url, auth0, out data);

                        if (data == "")

                        {

                            string createGroupURL = "/group";
                            XmlDocument = "<group name = \"" + group + "\" expand=\"attributes\"><type>GROUP</type><description>" + group + "</description><active>true</active><attributes><link rel =\"self\" href = \"/group?groupname=" + group + "\" /></attributes></group>";
                            retrive = new getResponse();
                            data = "";
                            retrive.POST(serverURL + createGroupURL, XmlDocument, auth0, out data);
                            log("Create Group - " + group + " - Result: group successfully created");

                        }

                        string addToGroupURL = "/user/group/direct?username=";
                        XmlDocument = "<group name=\"" + group + "\"/>";
                        retrive = new getResponse();
                        data = "";
                        retrive.POST(serverURL + addToGroupURL + userUnderProcess, XmlDocument, auth0, out data);
                        log("Add to Group - " + userUnderProcess + " - Result: was successfully added to the '" + group + "' group");
                        listBox1.Items.Add(group);

                    }
                }

            }

       
            this.DialogResult=true;


        }
    }

}    

