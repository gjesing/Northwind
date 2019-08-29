using Northwind.DataAccess;
using Northwind.Entities;
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

namespace Northwind.Gui.Desktop
{
    /// <summary>
    /// Interaction logic for HrUserControl.xaml
    /// </summary>
    public partial class HrUserControl : UserControl
    {
        private Employee selectedEmployee;
        public HrUserControl()
        {
            InitializeComponent();
            DisplayAllEmployees();
            DataContext = this;
        }
        public void DisplayAllEmployees()
        {
            employeeDataGrid.ItemsSource = new Repository().GetAllEmployees();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            selectedEmployee.FirstName = textBoxFirstName.Text;
            selectedEmployee.LastName = textBoxLastName.Text;
            selectedEmployee.Title = textBoxTitle.Text;
            selectedEmployee.TitleOfCourtesy = textBoxTitleOfCourtesy.Text;
            selectedEmployee.BirthDate = DateTime.Parse(datePickerBirthDate.Text);
            selectedEmployee.HireDate = DateTime.Parse(datePickerHireDate.Text);
            selectedEmployee.Address = textBoxAddress.Text;
            selectedEmployee.City = textBoxCity.Text;
            selectedEmployee.Region = textBoxRegion.Text;
            selectedEmployee.PostalCode = textBoxPostalCode.Text;
            selectedEmployee.Country = textBoxCountry.Text;
            selectedEmployee.HomePhone = textBoxHomePhone.Text;
            selectedEmployee.Extension = textBoxExtension.Text;
            selectedEmployee.Photo = Encoding.ASCII.GetBytes(textBoxPhoto.Text);
            selectedEmployee.Notes = textBoxNotes.Text;
            selectedEmployee.ReportsTo = int.Parse(textBoxReportsTo.Text);
            selectedEmployee.PhotoPath = textBoxPhotoPath.Text;
            new Repository().Update(selectedEmployee);
            DisplayAllEmployees();
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEmployee = employeeDataGrid.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                textBoxFirstName.Text = selectedEmployee.FirstName;
                textBoxLastName.Text = selectedEmployee.LastName;
                textBoxTitle.Text = selectedEmployee.Title;
                textBoxTitleOfCourtesy.Text = selectedEmployee.TitleOfCourtesy;
                datePickerBirthDate.Text = selectedEmployee.BirthDate.ToString();
                datePickerHireDate.Text = selectedEmployee.HireDate.ToString();
                textBoxAddress.Text = selectedEmployee.Address;
                textBoxCity.Text = selectedEmployee.City;
                textBoxRegion.Text = selectedEmployee.Region;
                textBoxPostalCode.Text = selectedEmployee.PostalCode;
                textBoxCountry.Text = selectedEmployee.Country;
                textBoxHomePhone.Text = selectedEmployee.HomePhone;
                textBoxExtension.Text = selectedEmployee.Extension;
                textBoxPhoto.Text = selectedEmployee.Photo.ToString();
                textBoxNotes.Text = selectedEmployee.Notes;
                textBoxReportsTo.Text = selectedEmployee.ReportsTo.ToString();
                textBoxPhotoPath.Text = selectedEmployee.PhotoPath;
            }
        }
    }
}
