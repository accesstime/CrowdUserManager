using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace CrowdUserManager
{

    public partial class BulkUpload : Window
    {
        string serverURL = "";
        string[] auth = new string[2];
        string userName="";
        string firstName = "";
        string lastName = "";
        string email = "";
        string company;
        string password = "";
        string Directory = "";
        string groups = "";

        public BulkUpload()
        {
            InitializeComponent();
            MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
        }

        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void log(string logText)
        {
            Logging make = new Logging();
            make.addLog(logText);

        }
        public void getCredentials()

        {
            string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xmlFile);
            foreach (XmlNode noda in doc.DocumentElement)


            {
                if (noda.Attributes["name"].Value == Directory) 
                {

                    serverURL = noda.Attributes["url"].Value + "/rest/usermanagement/1";
                    auth[0] = noda.Attributes["user"].Value;
                    auth[1] = noda.Attributes["password"].Value;


                }

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
                retrive.POST(serverURL + sendPassword + userName, XmlDocument, auth, out data);
                if (data == "")
                {
                    return;
                }

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




        public void getData(DataTable data)
        {       
            DataColumn Directory = data.Columns.Add("Directory");
            DataColumn Process = data.Columns.Add("Process");
            DataColumn Status = data.Columns.Add("Status");
            dataGrid.ItemsSource = data.DefaultView;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.CanUserAddRows = false;
            Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void verifyButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView row in dataGrid.Items)
            {
                row.Row["Directory"] = "";
                row.Row["Process"] = true;
            }

            string domain = "";
            string text = "";
            string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
            string  DefaultConfig = "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlFile);
            XmlNodeList elements = doc.GetElementsByTagName("template");


//Set Directory according to the email domains
            
                for (int i = 0; i < elements.Count; i++)
            {              
                domain=elements[i].InnerXml;
                if (elements[i].InnerXml == "default")
                { DefaultConfig = elements[i].ParentNode.Attributes["name"].Value; }
                foreach (DataRowView row in dataGrid.Items)
                {                 
                    text = row.Row.ItemArray[0].ToString();
                    Regex regex = new Regex(domain);
                    Match match = regex.Match(text);
                    if (match.Success)
                    {
                        row.Row["Directory"] = elements[i].ParentNode.Attributes["name"].Value;                    
                    }
                }
            }

//Set default Directory for unknown email domains
            
            foreach (DataRowView row in dataGrid.Items)
            {
        
                if (row.Row["Directory"].ToString() =="")
                {
                    row.Row["Directory"] = DefaultConfig;
                }

            }

//Verify users and emails

            foreach (DataRowView row in dataGrid.Items)
            {

                userName = row.Row["F4"].ToString();
                email = row.Row["F1"].ToString();
                Directory = row.Row["Directory"].ToString();
                string Status = "";
                getCredentials();


                string notFoundXML = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><users expand=\"user\"/>";
                string url = serverURL + "/search?entity-type=user";
                string XmlDocument = "<property-search-restriction><property><name>name</name><type>STRING</type></property><match-mode>EXACTLY_MATCHES</match-mode><value>" + userName + "</value></property-search-restriction>";
                getResponse retrive = new getResponse();
                string data = "";
                retrive.POST(url, XmlDocument, auth, out data);

                if (data != notFoundXML)
                {
                    row.Row["Process"] = false;
                    Status = "UserName already exists. ";
                    row.Row["Status"] = Status;
                   
                }
                notFoundXML = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><users expand=\"user\"/>";
                url = serverURL + "/search?entity-type=user";
                XmlDocument = "<property-search-restriction><property><name>email</name><type>STRING</type></property><match-mode>EXACTLY_MATCHES</match-mode><value>"+email+"</value></property-search-restriction>";
                retrive = new getResponse();
                data = "";
                retrive.POST(url, XmlDocument, auth, out data);

                if (data != notFoundXML)

                {
                    row.Row["Process"] = false;
                    row.Row["Status"] = Status + "Email already exists.";
                }

                if (row.Row["Status"].ToString() == "")
                { row.Row["Status"] = "Ready"; }

            }



        }

        private void DataGridCheckBoxRow_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
           
            userName = "";
            firstName = "";
            lastName = "";
            password = ""; 
            groups = "";
            email = "";


            foreach (DataRowView row in dataGrid.Items)
            {


                if (row.Row["Directory"].ToString() == "")
                {
                    MessageBox1("Please, verify accounts first ");
                    return;
                }
                if (row.Row["Process"].ToString() == "True")
                {
                    

                try
                    {
//create           
                    
                    userName = row.Row["F4"].ToString();                  
                    firstName = row.Row["F2"].ToString();
                    lastName = row.Row["F3"].ToString();
                    email = row.Row["F1"].ToString();
                    groups = "";
                    password = "Epam" + Convert.ToString(DateTime.Now) + "Epam";
                    Directory = row.Row["Directory"].ToString();
                        getCredentials();


                        
                        string url = serverURL + "/user";
                        string XmlDocument = "<user name=\"" + userName + "\" expand=\"attributes\"><first-name>" + firstName + "</first-name><last-name>" + lastName+ "</last-name><display-name>" + firstName+ " " + lastName + "</display-name><email>" + email + "</email><active>true</active><attributes><link rel=\"self\" href=\"/user/attribute?username=" + userName + "\"/></attributes><password><link rel=\"edit\" href=\"/user/password?username=" + userName + "\"/><value>" + password + "</value></password></user>";

                        
                    getResponse retrive = new getResponse();
                    string data = "";
                    retrive.POST(url, XmlDocument, auth, out data);
                    if (data == "")
                    {
                        return;
                    }


                    row.Row["Status"] = "Created. ";
 //   set group


                    groups = row.Row["F6"].ToString();
                    string[] group = groups.Split(',');
                    for (int i = 0; i < group.Length; i++)
                    {




                        string addToGroupURL = "/user/group/direct?username=";
                        XmlDocument = "<group name=\""+ group[i] + "\"/>";
                        retrive = new getResponse();
                        data = "";

                        
                        retrive.POST(serverURL + addToGroupURL + userName, XmlDocument, auth, out data);
                       
                       
                }
                    row.Row["Status"] = row.Row["Status"] + "Group assigned. ";

//send password


                    sendPassword();
                    row.Row["Status"] = "Processed";

                    log("Create (bulk mode) - " + userName + " - Result: successfully created in " + Directory + " directory and added to the "+ groups + " group/s. Email notification about the password sent to: " + email);
                    }

                    catch
                        (Exception ex)
                    {
                        MessageBox1(ex.Message);
                    }


            }


                else { row.Row["Status"] = "Skipped"; }
            } 
            
            
        }

        private void DataGridCheckBoxColumn_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }
    }
    }
    
