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

namespace DatabaseApplication
{
    /// <summary>
    /// Interaction logic for EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        public EditRecord()
        {
            InitializeComponent();
        }

        private void FindCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (ID.Text.Trim() == "")
            {
                MessageBox.Show("Missing unique customer ID", "Entry error",
                       MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            // Load data into text boxes for matching ID
            CustomerDataDataContext con = new CustomerDataDataContext();
            Customer cust = con.Customers.FirstOrDefault(c => c.CustomerID == ID.Text.Trim());

            // Check to see if cust is null
            if (cust == null)
            {
                MessageBox.Show("Customer not found", "Entry error",
                       MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            else
            {
                CompanyName.Text = cust.CompanyName;
                ContactName.Text = cust.ContactName;
                ContactTitle.Text = cust.ContactTitle;
                Country.Text = cust.Country;
                City.Text = cust.City;
                Region.Text = cust.Region;
                PostalCode.Text = cust.PostalCode;
                Address.Text = cust.Address;
                Phone.Text = cust.Phone;
                Fax.Text = cust.Fax;
            }
        }

        private void SaveEditButton_Click(object sender, RoutedEventArgs e)
        {
            // Edit data for Row and save changes
            CustomerDataDataContext con = new CustomerDataDataContext();
            Customer cust = con.Customers.FirstOrDefault(c => c.CustomerID == ID.Text.Trim());

            if (cust == null)
            {
                MessageBox.Show("Customer not found", "Entry error",
                       MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            else
            {
                cust.CompanyName = CompanyName.Text.Trim();
                cust.ContactName = ContactName.Text.Trim();
                cust.ContactTitle = ContactTitle.Text.Trim();
                cust.Country = Country.Text.Trim();
                cust.City = City.Text.Trim();
                cust.Region = Region.Text.Trim();
                cust.PostalCode = PostalCode.Text.Trim();
                cust.Address = Address.Text.Trim();
                cust.Phone = Phone.Text.Trim();
                cust.Fax = Fax.Text.Trim();

                con.SubmitChanges();

                MessageBox.Show("Customer " + cust.CustomerID + " was edited ok");
            }
            Application app = Application.Current;
            MainWindow main = (MainWindow)app.MainWindow;
            // Refresh grid
            main.RefreshGrid();
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

      
    }
}
