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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // Create an instance of data connection to database customer table
            CustomerDataDataContext con = new CustomerDataDataContext();

            // Create customer list
            List<Customer> customers = (from c in con.Customers select c).ToList();
            CustomerDataGrid.ItemsSource = customers;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddRecord addRecordWindow = new AddRecord();
            addRecordWindow.ShowDialog();
        }

        public void RefreshGrid()
        {
            CustomerDataDataContext con = new CustomerDataDataContext();

            List<Customer> customers = (from c in con.Customers select c).ToList();
            CustomerDataGrid.ItemsSource = customers;
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecord deleteRecordWindow = new DeleteRecord();
            deleteRecordWindow.ShowDialog();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditRecord_Click(object sender, RoutedEventArgs e)
        {
            EditRecord editRecordWindow = new EditRecord();
            editRecordWindow.ShowDialog();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }


    }
}
