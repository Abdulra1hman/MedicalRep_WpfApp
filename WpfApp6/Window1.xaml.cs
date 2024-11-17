using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Databasecontext Databasecontext = new Databasecontext();
        public Window1()
        {
            InitializeComponent();
            show();
        }

        public void show()
        {
            Assigments.ItemsSource= Databasecontext.COURSES.ToList();
        }

        private void Add_Assigment(object sender, RoutedEventArgs e)
        {
            Course assignment = new Course();

            assignment.title = title.Text;
            assignment.description = Description.Text;
            assignment.statues = (Statues.SelectedItem as ComboBoxItem)?.Content.ToString();
            assignment.student_id = int.Parse(Student_id.Text);

            Databasecontext.COURSES.Add(assignment);
            Databasecontext.SaveChanges();


            show();

        }

        private void update_Assigment(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(id.Text);

            var Respons= Databasecontext.COURSES.FirstOrDefault(x => x.id==ID);

            if (Respons == null)
            {
                MessageBox.Show("Course not found");
            }
            else 
            {
                Respons.title= title.Text;
                Respons.description= Description.Text;
                Respons.statues= (Statues.SelectedItem as ComboBoxItem)?.Content.ToString();
                Respons.student_id= int.Parse(Student_id.Text);

                Databasecontext.SaveChanges();
                show();
            }

        }

        private void delete_assigment(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(id.Text);

            var Respons = Databasecontext.COURSES.FirstOrDefault(x => x.id == ID);

            if (Respons == null) 
            {
                MessageBox.Show("Course not found");
            }
            else
            {
                Databasecontext.COURSES.Remove(Respons);
                Databasecontext.SaveChanges();


                show();

            }
        }
    }
}
