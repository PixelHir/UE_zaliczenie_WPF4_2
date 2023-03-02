using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UEWPF4_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> ListOfPersons = null;
        public MainWindow()
        {
            InitializeComponent();
            InitBinding();
        }
        private void InitBinding()
        {
            ListOfPersons = new List<Person>();
            ListOfPersons.Add(new Person(1, "Adam", "Kowalski", 24));
            ListOfPersons.Add(new Person(2, "Jan", "Kowalski", 23));
            ListOfPersons.Add(new Person(3, "Agnieszka", "Kowalczyk", 28));
            ListOfPersons.Add(new Person(4, "Janusz", "Abacki", 25));
            lstPersons.ItemsSource = ListOfPersons;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstPersons.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("LastName", ListSortDirection.Ascending));
        }

        private void RefreshList()
        {
            CollectionViewSource.GetDefaultView(lstPersons.ItemsSource).Refresh();
        }
        private void lstPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var np = new Person(0, "Imię", "Nazwisko", 0);
            ListOfPersons.Add(np);
            RefreshList();
            // Automatycznie focusujemy nowo dodany element
            lstPersons.SelectedItem = np;
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = lstPersons.SelectedItem as Person;
            //null safety
            if(item == null) return;
            ListOfPersons.Remove(item);
            RefreshList();
        }
    }
}
