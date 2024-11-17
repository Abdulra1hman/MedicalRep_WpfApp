using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int loginid;

        Databasecontext Databasecontext = new Databasecontext();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string username= UsernameData.Text;
            string password= PasswordData.Text;

            var Response = Databasecontext.Users.FirstOrDefault(x => x.username == username && x.password == password);
            if (Response == null)
            {
                MessageBox.Show("Invalid Email or password");
            }
            else if (Response.role == "Teacher")
            {
                MessageBox.Show("Welcome the Teacher 😘");
                Window1 window2 = new Window1();
                window2.Show();
                this.Close();
            }
            else 
            {
                loginid = Response.id;
                MessageBox.Show("Welcome the Student 😒");
                Window2 window3 = new Window2();
                window3.Show();
                this.Close();
            }
        }
    }
}