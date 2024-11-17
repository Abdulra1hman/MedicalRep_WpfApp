using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Databasecontext Databasecontext = new Databasecontext();
        public Window2()
        {
            InitializeComponent();
            show();
        }
        public void show()
        {

            int ID = MainWindow.loginid;
            Completed_Grid.ItemsSource = Databasecontext.COURSES.Where(K => K.statues == "Open" && K.student_id == ID).ToList();
            Open_Grid.ItemsSource = Databasecontext.COURSES.Where(k => k.statues == "Completed" && k.student_id == ID).ToList();

        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(id.Text);
            string statues = (Selected_Data.SelectedItem as ComboBoxItem)?.Content.ToString();

            var Respons = Databasecontext.COURSES.FirstOrDefault(g => g.id == ID);
            if (Respons == null)
            {
                MessageBox.Show("Assigment not found");
            }
            else
            {
                Respons.statues = statues;
                Databasecontext.SaveChanges();
                show();

            }


        }
    }
}
