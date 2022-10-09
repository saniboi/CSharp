using System.Collections.Generic;
using System.Windows;
using _13b_ListView.Entities;

namespace _13b_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // ListView1
            ListView1.Items.Clear();
            List<Person> personList = GetPersonList();

            foreach (Person person in personList)
            {
                ListView1.Items.Add(person);
            }

            // ListView2
            ListView2.Items.Clear();
            personList = GetPersonList();

            foreach (Person person in personList)
            {
                ListView2.Items.Add(person);
            }
        }

        private List<Person> GetPersonList()
        {
            return new List<Person>
            {
                new Person {Firstname = "Hans", Lastname = "Müller"},
                new Person {Firstname = "Sara", Lastname = "Meier" }
            };
        }
    }
}
