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
    /// Interaction logic for DeleteRecord.xaml
    /// </summary>
    public partial class DeleteRecord : Window
    {
        public DeleteRecord()
        {
            InitializeComponent();
        }

        private void OkBut_Click(object sender, RoutedEventArgs e)
        {
            // Using Cascade delete via foreign-key constraints
            if (CustID.Text.Trim() == "")
            {
                MessageBox.Show("Missing unique customer ID", "Entry error",
                       MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            CustomerDataDataContext con = new CustomerDataDataContext();
            Customer cust = con.Customers.FirstOrDefault(c => c.CustomerID == CustID.Text.Trim());

            // Check for null cust
            if (cust == null)
            {
                MessageBox.Show("Customer not found", "Entry error",
                      MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            else
            {
                con.Customers.DeleteOnSubmit(cust);
                con.SubmitChanges();
                MessageBox.Show("Customer " + CustID + " was deleted ok");
            }

            Application app = Application.Current;
            MainWindow main = (MainWindow)app.MainWindow;
            // Refresh grid
            main.RefreshGrid();
            DialogResult = true;
            
        }

        private void CnclBut_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
