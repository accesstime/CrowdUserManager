using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Xml;
using Microsoft.Win32;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;



namespace CrowdUserManager
{

    public partial class MainWindow : Window
    {

        string serverURL = "";
        string[] auth = new string[2];
        bool active = false;
        string setActive = "";
        string userName = "";
        string firstName = "";
        string lastName = "";
        string email = "";
        string company;
        int maxIndex;
        List<string> foundUsers = new List<string>();
        List<string> userGroupsList = new List<string>();

        string notFoundXML= "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><users expand=\"user\"/>";

        public MainWindow(string companyName)
        {
            InitializeComponent();
       
            resetPasswordButton.Visibility = Visibility.Hidden;
            copyGroupButton.Visibility = Visibility.Hidden;
            CrowdUserManger.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            company = companyName;
            getServerParameters(company);
            CrowdUserManger.Width = 437;
            ExpanderLabel.Content = "expand >>>";
        }


        public void MessageBox1(string message)
        {

            MessageBox1 MessageBox1 = new MessageBox1();
            MessageBox1.Show(message);

        }

        public void log(string logText)
        {
            Logging make = new Logging();
            make.addLog(logText);

        }

        private void cleanSearchFields()
        {

            CreateUpdateButton.Content = "Create";
            UserNameBox.Text = "";
            FirstNameBox.Text = "";
            LastNameBox.Text = "";
            EmailBox.Text = "";
            ActiveCheckBox.IsChecked = true;
            resetPasswordButton.Visibility = Visibility.Hidden;
            copyGroupButton.Visibility = Visibility.Hidden;
            UserGropsListBox.Items.Clear();
  
            listBoxAvailibleGroups.Items.Clear();
            attributsButton.Visibility = Visibility.Hidden;
            recreateUserButton.Visibility = Visibility.Hidden;
        }

        private void listBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                cleanSearchFields();

                SearchTextBox.Text = listBox.SelectedItem.ToString();
                SearchButton_Click(sender,e);
            }

        }

        public void getCredentials()

        {
            string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlFile);
            foreach (XmlNode noda in doc.DocumentElement)


            {
                if (noda.Attributes["name"].Value == DirectoryComboBox.Text && noda.Attributes["company"].Value == company)
                {
                    serverURL = noda.Attributes["url"].Value + "/rest/usermanagement/1";
                    auth[0] = noda.Attributes["user"].Value;
                    auth[1] = noda.Attributes["password"].Value;

                }
            }
        }

        public void GroupsTab()
        {
            try
            {

                existingGroupsComboBox.Items.Clear();
                string urlGroupSearch = serverURL + "/search?entity-type=group";
                getResponse retrive = new getResponse();
                string groupList = "";
                retrive.GET(urlGroupSearch, auth, out groupList);


                XmlDocument doc = new XmlDocument();
                doc.LoadXml(groupList);
                foreach (XmlNode noda in doc.DocumentElement)
                {
                    if (noda.LocalName == "group")

                        existingGroupsComboBox.Items.Add(noda.Attributes["name"].Value);
                }

                existingGroupsComboBox.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }

        }

        public void getGroup()

        {

            try
            {

                
                listBoxAvailibleGroups.Items.Clear();
                string urlGroupSearch = serverURL + "/search?entity-type=group";
                getResponse retrive = new getResponse();
                string groupList = "";
                retrive.GET(urlGroupSearch, auth, out groupList);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(groupList);
                foreach (XmlNode noda in doc.DocumentElement)
                {
                    if (noda.LocalName == "group")
                        
                        listBoxAvailibleGroups.Items.Add(noda.Attributes["name"].Value);
                }

                

            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }

        }

        public void getUserGroup()

        {
            try
            {
                UserGropsListBox.Items.Clear();
                string urlUserGroupSearch = serverURL + "/user/group/direct?username=" + UserNameBox.Text;
                getResponse retrive = new getResponse();
                string groupList = "";
                retrive.GET(urlUserGroupSearch, auth, out groupList);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(groupList);
                foreach (XmlNode noda in doc.DocumentElement)
                {

                    if (noda.LocalName == "group")
                        UserGropsListBox.Items.Add(noda.Attributes["name"].Value);
                }
            }


            catch

                (Exception ex)
            {
                MessageBox1(ex.Message);
            }


        }

        public void sendPassword()
        {

            try
            {

                string sendPassword = "/user/mail/password?username=";
                string XmlDocument = "";
                getResponse retrive = new getResponse();
                string data = "";
                retrive.POST(serverURL + sendPassword + UserNameBox.Text, XmlDocument, auth, out data);


            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }

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


                    if (noda.LocalName == "server" && noda.Attributes["company"].Value == company)

                        DirectoryComboBox.Items.Add(noda.Attributes["name"].Value);
                }

            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }



        }


        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        public void severalUsersFound()

        {
            
            MessageBox1(foundUsers.Count.ToString()+ " users found.");
            nextUserButton.Visibility = Visibility.Visible;
          
        }

        public void getUserByUserName()

        {
            string url = serverURL + "/search?entity-type=user";
            string XmlDocument = "<property-search-restriction><property><name>name</name><type>STRING</type></property><match-mode>EXACTLY_MATCHES</match-mode><value>" + SearchTextBox.Text + "</value></property-search-restriction>";
            getResponse retrive = new getResponse();
            string data = "";
            retrive.POST(url, XmlDocument, auth, out data);
            if (data == notFoundXML)

            {
                cleanSearchFields();

            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            foreach (XmlNode noda in doc.DocumentElement)
            {
                if (noda.LocalName == "user")
                {

                    UserNameBox.Text = noda.Attributes["name"].Value;
                    userName = noda.Attributes["name"].Value;
                    
                }
            }

          
            try
            {
                string urlUserSearch = serverURL + "/user?username=" + UserNameBox.Text;
                retrive = new getResponse();
                string userInfo = "";
                retrive.GET(urlUserSearch, auth, out userInfo);
                doc = new XmlDocument();
                doc.LoadXml(userInfo);
                foreach (XmlNode noda in doc.DocumentElement)
                {

                    if (noda.LocalName == "active")
                        active = Convert.ToBoolean(noda.FirstChild.Value);
                    else if (noda.LocalName == "first-name")
                        firstName = noda.FirstChild.Value;
                    else if (noda.LocalName == "last-name")
                        lastName = noda.FirstChild.Value;
                    else if (noda.LocalName == "email")
                        email = noda.FirstChild.Value;
                }

                FirstNameBox.Text = firstName;
                LastNameBox.Text = lastName;
                EmailBox.Text = email;
                if (active == true)
                    ActiveCheckBox.IsChecked = true;
                else
                    ActiveCheckBox.IsChecked = false;

//Set lable Update on the button if the user was found

               

               resetPasswordButton.Visibility = Visibility.Visible;
               copyGroupButton.Visibility = Visibility.Visible;
                CreateUpdateButton.Content = "Update";
                log("Search - " + SearchTextBox.Text + " - Result: Found username - " + userName);
                attributsButton.Visibility = Visibility.Visible;
                recreateUserButton.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                cleanSearchFields();

            }

            //Find a groups for the user 

            getUserGroup();

            // Retrive groups list 

            getGroup();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            userName = "";
            foundUsers.Clear();
            maxIndex = 0;
            nextUserButton.Visibility = Visibility.Hidden;         
            SearchTextBox.Text=SearchTextBox.Text.TrimStart(' ').TrimEnd(' ');
// if field search is empty

            if (SearchTextBox.Text == "")
            {
                MessageBox1("Search field is empty.");
                return;
            }
// if master mode should be enabled
            if (SearchTextBox.Text == "#master")
            {
                DeleteUserButton.Visibility = Visibility.Visible;
                deleteGroupButton.Visibility = Visibility.Visible;
                return;
            }
    
           
                
            
// User search

            string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
            XmlDocument configuration = new XmlDocument();

            configuration.LoadXml(xmlFile);
            foreach (XmlNode tag in configuration.DocumentElement)
            {
               
                if (userName != "")
                {                   
                    return;
                }

                if (tag.Attributes["company"].Value == company)
                {
                    string directory = tag.Attributes["name"].Value;
                    serverURL = tag.Attributes["url"].Value + "/rest/usermanagement/1";
                    auth[0] = tag.Attributes["user"].Value;
                    auth[1] = tag.Attributes["password"].Value;
                    DirectoryComboBox.Text = directory;

// if string contains @ symbol do search by email address

                    if (SearchTextBox.Text.Contains("@") == true)
                    {

                        string url = serverURL + "/search?entity-type=user";
                        string XmlDocument = "<property-search-restriction><property><name>email</name><type>STRING</type></property><match-mode>EXACTLY_MATCHES</match-mode><value>" + SearchTextBox.Text + "</value></property-search-restriction>";
                        getResponse retrive = new getResponse();
                        string data = "";
                        retrive.POST(url, XmlDocument, auth, out data);

                        if (data == notFoundXML)

                        {

                            cleanSearchFields();
                            url = serverURL + "/search?entity-type=user";
                            XmlDocument = "<property-search-restriction><property><name>name</name><type>STRING</type></property><match-mode>EXACTLY_MATCHES</match-mode><value>" + SearchTextBox.Text.Substring(0, SearchTextBox.Text.IndexOf("@")) + "</value></property-search-restriction>";
                            retrive = new getResponse();
                            data = "";
                            retrive.POST(url, XmlDocument, auth, out data);
                            if (data == notFoundXML)

                            {
                                cleanSearchFields();

                            }
                        }

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(data);
                        foreach (XmlNode noda in doc.DocumentElement)
                        {
                            if (noda.LocalName == "user")
                            {

                                UserNameBox.Text = noda.Attributes["name"].Value;
                                userName = noda.Attributes["name"].Value;
                               
                                foundUsers.Add(userName);

                            }
                        }

                        if (foundUsers.Count > 1)

                        {
                            severalUsersFound();

                        }

                        try
                        {

                            string urlUserSearch = serverURL + "/user?username=" + UserNameBox.Text;
                            retrive = new getResponse();
                            string userInfo = "";
                            retrive.GET(urlUserSearch, auth, out userInfo);

                            doc = new XmlDocument();
                            doc.LoadXml(userInfo);
                            foreach (XmlNode noda in doc.DocumentElement)
                            {

                                if (noda.LocalName == "active")
                                    active = Convert.ToBoolean(noda.FirstChild.Value);
                                else if (noda.LocalName == "first-name")
                                    firstName = noda.FirstChild.Value;
                                else if (noda.LocalName == "last-name")
                                    lastName = noda.FirstChild.Value;
                                else if (noda.LocalName == "email")
                                    email = noda.FirstChild.Value;
                            }

                            FirstNameBox.Text = firstName;
                            LastNameBox.Text = lastName;
                            EmailBox.Text = email;
                            if (active == true)
                                ActiveCheckBox.IsChecked = true;
                            else
                                ActiveCheckBox.IsChecked = false;


//Set lable Update on the button if the user was found

                            
                            resetPasswordButton.Visibility = Visibility.Visible;
                            copyGroupButton.Visibility = Visibility.Visible;

                            CreateUpdateButton.Content = "Update";
                            log("Search - " + SearchTextBox.Text + " - Result: Found username - " + userName);
                            attributsButton.Visibility = Visibility.Visible;
                            recreateUserButton.Visibility = Visibility.Visible;
                        }

                        catch (Exception ex)
                        {
                            cleanSearchFields();

                        }

//Find a groups for the user 

                        getUserGroup();

// Retrive groups list 

                        getGroup();


                    }

//If first name and last name provided

                    else if (SearchTextBox.Text.Contains(" "))
                    {
                     
                        string url = serverURL + "/search?entity-type=user&restriction=displayName%20=%20%22*"+SearchTextBox.Text+ "*%22";
                        getResponse retrive = new getResponse();
                        string data = "";
                        retrive.GET(url, auth, out data);

                        if (data == notFoundXML)

                        {
                            cleanSearchFields();

                        }

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(data);
                        foreach (XmlNode noda in doc.DocumentElement)
                        {
                            if (noda.LocalName == "user")
                            {

                                UserNameBox.Text = noda.Attributes["name"].Value;
                                userName = noda.Attributes["name"].Value;
                                
                                foundUsers.Add(userName);

                            }
                        }

                        if (foundUsers.Count > 1)

                        {
                            severalUsersFound();

                        }

                        try
                        {

                            string urlUserSearch = serverURL + "/user?username=" + UserNameBox.Text;
                            retrive = new getResponse();
                            string userInfo = "";
                            retrive.GET(urlUserSearch, auth, out userInfo);

                            doc = new XmlDocument();
                            doc.LoadXml(userInfo);
                            foreach (XmlNode noda in doc.DocumentElement)
                            {

                                if (noda.LocalName == "active")
                                    active = Convert.ToBoolean(noda.FirstChild.Value);
                                else if (noda.LocalName == "first-name")
                                    firstName = noda.FirstChild.Value;
                                else if (noda.LocalName == "last-name")
                                    lastName = noda.FirstChild.Value;
                                else if (noda.LocalName == "email")
                                    email = noda.FirstChild.Value;
                            }

                            FirstNameBox.Text = firstName;
                            LastNameBox.Text = lastName;
                            EmailBox.Text = email;
                            if (active == true)
                                ActiveCheckBox.IsChecked = true;
                            else
                                ActiveCheckBox.IsChecked = false;

                            //Set lable Update on the button if the user was found
                            resetPasswordButton.Visibility = Visibility.Visible;
                            copyGroupButton.Visibility = Visibility.Visible;

                            CreateUpdateButton.Content = "Update";
                            log("Search - " + SearchTextBox.Text + " - Result: Found username - " + userName);
                            attributsButton.Visibility = Visibility.Visible;
                            recreateUserButton.Visibility = Visibility.Visible;
                        }

                        catch (Exception ex)
                        {
                            cleanSearchFields();

                        }

                        //Find a groups for the user 

                        getUserGroup();

                        // Retrive groups list 

                        getGroup();

                }


// if search box contains username
                    else
                    {

                        getUserByUserName();

                    }

                }
               
            }


            if (userName == "")
            {
                listBoxAvailibleGroups.Items.Clear();
                MessageBox1("User not found!");
                if (SearchTextBox.Text.Contains("@"))
                {
                    EmailBox.Text = SearchTextBox.Text;
                    UserNameBox.Text = SearchTextBox.Text.Substring(0, SearchTextBox.Text.IndexOf("@"));
                    string compOfAcc = SearchTextBox.Text.Substring(SearchTextBox.Text.IndexOf("@")+1, SearchTextBox.Text.LastIndexOf(".")- SearchTextBox.Text.IndexOf("@")-1) ;
                    LastNameBox.Text= " ("+char.ToUpper(compOfAcc[0]) + compOfAcc.Substring(1) + ")";
                    //LastNameBox.Text = SearchTextBox.Text.LastIndexOf(".").ToString();
                }
                log("Search - " + SearchTextBox.Text + " - Result: Not Found");
                
            }

            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
          Close();
        }

        private void textBox_Copy4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreateUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UserNameBox.Text = UserNameBox.Text.TrimStart(' ').TrimEnd(' ');
            EmailBox.Text = EmailBox.Text.TrimStart(' ').TrimEnd(' ');
            FirstNameBox.Text=FirstNameBox.Text.TrimStart(' ').TrimEnd(' ');
            LastNameBox.Text= LastNameBox.Text.TrimStart(' ').TrimEnd(' ');
            getCredentials();

            if (CreateUpdateButton.Content == "Update")

            {


                if (UserNameBox.Text == "" || FirstNameBox.Text == "" || LastNameBox.Text == "" || EmailBox.Text == "")
                {

                    MessageBox1("Some of the mandatory fields are empty.");


                }
                else
                {

                    try
                    {
                        if (userName != UserNameBox.Text)
                        {

                            MessageBox1("This version of the application is not allowed to update 'User Name' field due to limitaions from the Atlassian Crowd side. https://jira.atlassian.com/browse/CWD-3388?src=confmacro If you anyway need this functionality please contact with Epam developers");
                            return;
                        }



                       

                        if (ActiveCheckBox.IsChecked == true)
                        { setActive = "true"; }
                        else { setActive = "false"; }
                        string url = serverURL + "/user?username=" + UserNameBox.Text;
                        string XmlDocument = "<user name=\"" + UserNameBox.Text + "\" expand=\"attributes\"><first-name>" + FirstNameBox.Text + "</first-name><last-name>" + LastNameBox.Text + "</last-name><display-name>" + FirstNameBox.Text + " " + LastNameBox.Text + "</display-name><email>" + EmailBox.Text + "</email><active>" + setActive + "</active><attributes><link rel=\"self\" href=\"/user/attribute?username=" + UserNameBox.Text + "\"/></attributes><password><link rel=\"edit\" href=\"/user/password?username=" + UserNameBox.Text + "\"/><value></value></password></user>";
                        getResponse retrive = new getResponse();
                        string data = "";
                        retrive.PUT(url, XmlDocument, auth,out data);
                        MessageBox1("Updated successfully");
                        log("Update - " + UserNameBox.Text + " - Result: updated successfully");
                    }


                    catch

                        (Exception ex)
                    {
                        MessageBox1(ex.Message);
                    }

                }


            }

//Create User, send password link and assign to the jira-users group 


            else
            {
                if (UserNameBox.Text == "" || FirstNameBox.Text == "" || LastNameBox.Text == "" || EmailBox.Text == "")
                {
                    MessageBox1("Some of the mandatory fields are empty.");
                }
                else
                {
                    try
                    {
//create    
                       
                        string pass = "Epam" + Convert.ToString(DateTime.Now.Millisecond) + "Epam";
                        if (ActiveCheckBox.IsChecked == true)
                        { setActive = "true"; }
                        else { setActive = "false"; }
                        string url = serverURL + "/user";
                        string XmlDocument = "<user name=\"" + UserNameBox.Text + "\" expand=\"attributes\"><first-name>" + FirstNameBox.Text + "</first-name><last-name>" + LastNameBox.Text + "</last-name><display-name>" + FirstNameBox.Text + " " + LastNameBox.Text + "</display-name><email>" + EmailBox.Text + "</email><active>" + setActive + "</active><attributes><link rel=\"self\" href=\"/user/attribute?username=" + UserNameBox.Text + "\"/></attributes><password><link rel=\"edit\" href=\"/user/password?username=" + UserNameBox.Text + "\"/><value>" + pass + "</value></password></user>";
                        getResponse retrive = new getResponse();
                        string data = "";
                        retrive.POST(url, XmlDocument, auth,out data);
                        
//set group
                        string addToGroupURL = "/user/group/direct?username=";
                        XmlDocument = "<group name=\"jira-users\"/>";
                        retrive = new getResponse();
                        data = "";
                        retrive.POST(serverURL + addToGroupURL + UserNameBox.Text, XmlDocument, auth,out data);

//send password 

                        sendPassword();
                        MessageBox1("User '" + UserNameBox.Text + "' was successfully created and added to the 'jira-users' group. Email notification about the password sent to the " + EmailBox.Text);
                        log("Create - " + UserNameBox.Text + " - Result: successfully created in "+DirectoryComboBox.Text+ " directory and added to the 'jira-users' group. Email notification about the password sent to: " + EmailBox.Text);
                        Clipboard.SetText("Account '" + UserNameBox.Text + "' was successfully created .Reset password link was sent to " + EmailBox.Text);
                        SearchButton_Click(sender,e);

                    }

                    catch
                        (Exception ex)
                    {
                        MessageBox1(ex.Message);
                    }

                }


            }

        }

        private void addToGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxAvailibleGroups.SelectedItems.Count == 0)
            {
                MessageBox1("Please, select one or several groups first");
            }
            else
            {
                getCredentials();
                string addToGroupURL = "/user/group/direct?username=";
                foreach (string selectedGroup in listBoxAvailibleGroups.SelectedItems)
                {
                    string XmlDocument = "<group name=\"" + selectedGroup + "\"/>";
                    getResponse retrive = new getResponse();
                    string data = "";
                    retrive.POST(serverURL + addToGroupURL + UserNameBox.Text, XmlDocument, auth, out data);
                    log("Add to Group - " + UserNameBox.Text + " - Result: was successfully added to the '" + selectedGroup + "' group");

                }
                MessageBox1("User '" + UserNameBox.Text + "' was successfully added to selected group/s");
                getUserGroup();
            }

        }


        public void DirectoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            existingGroupsComboBox.Items.Clear();
            totalMembersCountTextBlock.Text = "";
            listBox.Items.Clear();

        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameBox.Text == "")
            {
                MessageBox1("'User Name' field is empty");
                return;

            }

            DialogBox DialogBox1 = new DialogBox();
            DialogBox1.Show("User '" + UserNameBox.Text + "' will be deleted from the system. Would you like to continue?");

            if (DialogBox1.DialogResult == true)
            {

                getCredentials();
                
                string removeUserURL = "/user?username=" + UserNameBox.Text;
                getResponse retrive = new getResponse();
                string data = "";
                retrive.DELETE(serverURL + removeUserURL, auth, out data);
                MessageBox1("User '" + UserNameBox.Text + "' was successfully removed from the system");
                log("Delete User - " + UserNameBox.Text + " - Result: successfully removed from the system");

            }

        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Comma-Separated Values |*.csv|All files (*.*)|*.*";
            dialog.CheckFileExists = false;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)

            {


                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = \"" + System.IO.Path.GetDirectoryName(dialog.FileName) + "\"; Extended Properties = \"Text;HDR=NO;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter
                ("SELECT * FROM " + dialog.SafeFileName, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                conn.Close();
                BulkUpload toUpload = new BulkUpload();
                toUpload.getData(table);

            }


        }

        private void createGroupButton_Click(object sender, RoutedEventArgs e)
        {


           

            if (createGroupTextBox.Text.Contains("&") || createGroupTextBox.Text.Contains("/") || createGroupTextBox.Text.Contains("?") || createGroupTextBox.Text.Contains("\\"))
                {
                MessageBox1("'Group name' field contains an illegal character/s. If you anyway would like to create group with such name please use Crowd web interface");
                return;

            }

            

            if (createGroupTextBox.Text == "")
            {

                MessageBox1("Please fill the 'Group name' box first.");
                return;
            }
            getCredentials();
            string createGroupURL = "/group";
            string XmlDocument = "<group name = \"" + createGroupTextBox.Text + "\" expand=\"attributes\"><type>GROUP</type><description>" + createGroupTextBox.Text + "</description><active>true</active><attributes><link rel =\"self\" href = \"/group?groupname=" + createGroupTextBox.Text + "\" /></attributes></group>";
            getResponse retrive = new getResponse();
            string data = "";
            retrive.POST(serverURL + createGroupURL, XmlDocument, auth,out data);      
            MessageBox1("'" + createGroupTextBox.Text + "' group was successfully created");
            GroupsTab();
            log("Create Group - " + createGroupTextBox.Text + " - Result: group successfully created");

        }

        private void getGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            getCredentials();

            GroupsTab();

            log("Get Groups List - Directory: " +DirectoryComboBox.Text);

        }

        private void deleteGroupButton_Click(object sender, RoutedEventArgs e)
        {

            if (existingGroupsComboBox.Text == "")
            {
                MessageBox1("Please, select group to delete first");
                return;

            }
            DialogBox DialogBox1 = new DialogBox();

            DialogBox1.Show("Group "+ existingGroupsComboBox.Text + " will be deleted from the system. Would you like to continue?");
            if (DialogBox1.DialogResult == true)
            {
                getCredentials();
                string urlGroupSearch = serverURL + "/group?groupname=" + existingGroupsComboBox.Text;
                getResponse retrive = new getResponse();
                string groupList = "";
                retrive.DELETE(urlGroupSearch, auth, out groupList);
                MessageBox1(existingGroupsComboBox.Text + " group successfully deleted");
                GroupsTab();
                log("Delete Group - " + existingGroupsComboBox.Text+ ". Result: group successfully deleted");
            }
                }

        private void GetMambersButton_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            totalMembersCountTextBlock.Text = "";
            if (existingGroupsComboBox.Text == "")
            {
                MessageBox1("Please, select group first.");


                    return; }
            try
            {

              
                string urlGroupMembersSearch = serverURL + "/group/user/direct?groupname="+existingGroupsComboBox.Text+ "&max-result=10000";
                getResponse retrive = new getResponse();
                string groupMembersList = "";
                retrive.GET(urlGroupMembersSearch, auth, out groupMembersList);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(groupMembersList);
                foreach (XmlNode noda in doc.DocumentElement)
                {
                    if (noda.LocalName == "user")
                        listBox.Items.Add(noda.Attributes["name"].Value);
                }

                totalMembersCountTextBlock.Text = "Total: "+ listBox.Items.Count ;
                log("Get Group Members - " + existingGroupsComboBox.Text + ". Result: "+totalMembersCountTextBlock.Text+": users found");

            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }
        }

        private void existingGroupsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            totalMembersCountTextBlock.Text = "";
            listBox.Items.Clear();
        }

        private void SearchComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void resetPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

       
        private void lable_MouseClick(object sender, RoutedEventArgs e)
        {

            if (ExpanderLabel.Content == "expand >>>")
            {
                CrowdUserManger.Width = 840;
                ExpanderLabel.Content = "reduce <<<";
            }

            else
            {
                CrowdUserManger.Width = 437;
                ExpanderLabel.Content = "expand >>>";
            }

        }

        private void deleteUserFromGroup_Click(object sender, RoutedEventArgs e)
        {
            string groupListToDelete="";
            foreach (var group in UserGropsListBox.SelectedItems)
            {
                groupListToDelete+= " '"+group.ToString()+"' ";
            }

            DialogBox DialogBox1 = new DialogBox();
            DialogBox1.Show("User '"+UserNameBox.Text+"' will be removed from the groups:"+groupListToDelete+". Would you like to continue?");

            if (DialogBox1.DialogResult == true)
            {

                foreach (var group in UserGropsListBox.SelectedItems)
                {
                   
                    getCredentials();
                    string removeFromTheGroupURL = "/user/group/direct?username=" + UserNameBox.Text + "&groupname=" + group.ToString();
                    getResponse retrive = new getResponse();
                    string data = "";
                    retrive.DELETE(serverURL + removeFromTheGroupURL, auth, out data);           

                }
                getUserGroup();
                log("Remove User From Group - " + UserNameBox.Text + ". Result: user removed from the groups:" + groupListToDelete);


            }

        }


        //private void logo_Click(object sender, RoutedEventArgs e)

        //{
        //    System.Diagnostics.Process proc = new System.Diagnostics.Process();
        //    proc.StartInfo.FileName = "mailto:support@accesstime.online?subject=ServiceRequest // "+DateTime.UtcNow.ToUniversalTime();
        //    proc.Start();
        //}

        private void attributsButton_Click(object sender, RoutedEventArgs e)
        {
            string attributes = "";
            string urlUserAttributes = serverURL + "/user/attribute?username="+UserNameBox.Text;
            getResponse retrive = new getResponse();
            string attributesList = "";
            retrive.GET(urlUserAttributes, auth, out attributesList);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(attributesList);
            foreach (XmlNode noda in doc.DocumentElement)
            {
                if (noda.LocalName == "attribute")
                {
                    
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    switch (noda.Attributes["name"].Value)
                    {
                        case "requiresPasswordChange": attributes += "Requires Password Change : " + noda.InnerText + "\r\n";
                            break;
                        case "invalidPasswordAttempts": attributes += "Invalid Password Attempts : " + noda.InnerText + "\r\n";
                            break;
                        case "autoGroupsAdded": attributes += "Auto Groups Added : " + noda.InnerText + "\r\n";
                            break;
                        case "lastActive": attributes += "Last Active : " + epoch.AddMilliseconds(Convert.ToInt64(noda.InnerText)).ToString()+ "\r\n";
                            break;
                        case "lastAuthenticated": attributes += "Last Authenticated : " + epoch.AddMilliseconds(Convert.ToInt64(noda.InnerText)).ToString() + "\r\n";
                            break;
                        case "passwordLastChanged":attributes += "Password Last Changed : " + epoch.AddMilliseconds(Convert.ToInt64(noda.InnerText)).ToString() + "\r\n";
                            break;
                        default:continue;
                    }

                }
            }

           MessageBox1(attributes);

        }

        private void nextUserButton_Click(object sender, RoutedEventArgs e)
        {
         
                SearchTextBox.Text = foundUsers[maxIndex];
                getUserByUserName();

            if (maxIndex == foundUsers.Count - 1)
            {
                maxIndex = 0;
            }
            else
            {
                maxIndex++;
            }

        }

        private void ActiveCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

      

        private void resetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
 
            sendPassword();
            MessageBox1("Reset password link sent to " + UserNameBox.Text);
            log("Reset Password - " + UserNameBox.Text + " - Reset password link sent");

        }

        private void copyGroupButton_Click(object sender, RoutedEventArgs e)
        {
            userGroupsList.Clear();

            foreach (var item in UserGropsListBox.Items)
            {
                userGroupsList.Add(item.ToString());
            }
            
            groupCopyWindow copyGroup = new groupCopyWindow();
            copyGroup.getServerParameters(company,UserNameBox.Text, FirstNameBox.Text, LastNameBox.Text, userGroupsList,auth);
     
            copyGroup.ShowDialog();
            if (copyGroup.DialogResult == true)

            {
                SearchButton_Click(sender, e);
            }


        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {

            try {
                System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\Logging\\Log01.log");
                }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\application.conf");
            }

            catch (Exception ex)
            {
                MessageBox1(ex.Message);
            }

        }

        private void recreateUserButton_Click(object sender, RoutedEventArgs e)
        {

            userGroupsList.Clear();

            foreach (var item in UserGropsListBox.Items)
            {
                userGroupsList.Add(item.ToString());
            }

            recreateUserInNewDomain recreate = new recreateUserInNewDomain(company ,DirectoryComboBox.Text ,UserNameBox.Text,FirstNameBox.Text,LastNameBox.Text,EmailBox.Text, userGroupsList);
            recreate.ShowDialog();
            if (recreate.DialogResult == true)
            {
                SearchButton_Click(sender, e);
            }
        }
    }
}