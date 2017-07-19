using System.Windows;


namespace CrowdUserManager
{
    /// <summary>
    /// Interaction logic for MessageBox1.xaml
    /// </summary>
    public partial class MessageBox1 : Window
    {


        public void Show(string message)
        {

            InitializeComponent();
            messageTextBlock.Text = message;
            this.ShowDialog();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


            this.Close();

        }
    }
}
