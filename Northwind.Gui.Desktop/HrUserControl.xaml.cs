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
            PopulateComboBoxes();
            DataContext = this;
        }
        public void DisplayAllEmployees()
        {
            employeeDataGrid.ItemsSource = new Repository().GetAllEmployees();
        }
        public void PopulateComboBoxes()
        {
            List<Employee> employees = new Repository().GetAllEmployees();
            foreach (var id in employees.Select(employee => employee.EmployeeID).ToList())
            {
                comboBoxReportsTo.Items.Add(id);
            }
        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            selectedEmployee.FirstName = textBoxFirstName.Text;
            selectedEmployee.LastName = textBoxLastName.Text;
            selectedEmployee.Title = textBoxTitle.Text;
            selectedEmployee.TitleOfCourtesy = comboBoxTitleOfCourtesy.Text;
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
            selectedEmployee.ReportsTo = int.Parse(comboBoxReportsTo.Text);
            selectedEmployee.PhotoPath = textBoxPhotoPath.Text;
            new Repository().Update(selectedEmployee);
            textBoxFirstName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxTitle.Text = string.Empty;
            comboBoxTitleOfCourtesy.SelectedValue = string.Empty;
            datePickerBirthDate.Text = string.Empty;
            datePickerHireDate.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
            textBoxCity.Text = string.Empty;
            textBoxRegion.Text = string.Empty;
            textBoxPostalCode.Text = string.Empty;
            textBoxCountry.Text = string.Empty;
            textBoxHomePhone.Text = string.Empty;
            textBoxExtension.Text = string.Empty;
            textBoxPhoto.Text = string.Empty;
            textBoxNotes.Text = string.Empty;
            comboBoxReportsTo.Text = string.Empty;
            textBoxPhotoPath.Text = string.Empty;
            buttonUpdate.IsEnabled = false;
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
                comboBoxTitleOfCourtesy.Text = selectedEmployee.TitleOfCourtesy;
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
                comboBoxReportsTo.Text = selectedEmployee.ReportsTo.ToString();
                textBoxPhotoPath.Text = selectedEmployee.PhotoPath;
                buttonUpdate.IsEnabled = true;
            }
        }
    }
}
