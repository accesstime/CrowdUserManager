using System;
using System.Windows;
using System.IO;
using System.Xml;

namespace CrowdUserManager
{
    /// <summary>
    /// Interaction logic for CompanySelector.xaml
    /// </summary>
    public partial class CompanySelector : Window
    {
        public CompanySelector()
        {
            InitializeComponent();
            getCompany();
        }

        public void getCompany()

        {
            string xmlFile = File.ReadAllText(Environment.CurrentDirectory + "\\application.conf");
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xmlFile);
            foreach (XmlNode noda in doc.DocumentElement)
            {
                if (noda.LocalName == "server")

                    if (companyComboBox.Items.Contains(noda.Attributes["company"].Value))
                    { }

                 else

                    companyComboBox.Items.Add(noda.Attributes["company"].Value);
            }


            if (companyComboBox.Items.Count == 1)
            {
                
                MainWindow start = new MainWindow(companyComboBox.Text);
                start.Show();
                Close();
            }

        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

           
            MainWindow start = new MainWindow(companyComboBox.Text);
            start.Show();
            Close();

        }
    }
}
