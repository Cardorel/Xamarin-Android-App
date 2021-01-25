using EmployeeMobileApp.Models;
using EmployeeMobileApp.Services;
using EmployeeMobileApp.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace EmployeeMobileApp.ViewModels
{
    [QueryProperty(nameof(EmployeeName), nameof(EmployeeName))]
    public class EmployeeDetailViewModel : BaseViewModel
    {
        private string employeeName;
        private string name;
        private string position;
        private DateTime birthday;
        private ImageSource photo;
        private int age = 0;
        public string Id { get; set; }

        public EmployeeDetailViewModel()
        {
            Title = "Employee detail";
            EditCommand = new Command(CurrentEmployee);
            DeleteEmployeeCommand = new Command(DeleteCurrentEmployee);
        }

        //Get current Employee
        public async Task<Employee> GetEmployeeAsync(string name)
        {
            return await Task.FromResult(DataStore.GetEmployees.FirstOrDefault(e => e.Name == name));
        }

        //Load an employee in the page
        public async void LoadEmployeeName(string name)
        {
            try
            {
                var employee = await GetEmployeeAsync(name);
                Id = employee.Id;
                Name = employee.Name;
                Position = employee.Position;
                Birthday = employee.Birthday;
                //Calculate Age of current employee
                Age = new DateTime(DateTime.Now.Subtract(employee.Birthday).Ticks).Year - 1;
                Photo = employee.Photo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Debug.WriteLine("Failed to Load employee");
            }
        }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Position { get => position; set => SetProperty(ref position, value); }
        public DateTime Birthday { get => birthday; set => SetProperty(ref birthday, value); }
        public ImageSource Photo { get => photo; set => SetProperty(ref photo, value); }
        public int Age { get => age; set => SetProperty(ref age, value); }

        public string EmployeeName
        {
            get => employeeName;
            set
            {
                SetProperty(ref employeeName, value);
                //Get current name for the url
                LoadEmployeeName(HttpUtility.UrlDecode(employeeName));

            }
        }

        //Set a route for Edit Page and set this current Id;
        async void CurrentEmployee()
        {
            await Shell.Current.GoToAsync($"{nameof(EditEmployePage)}?{nameof(EditEmployeeViewModel.Id)}={Id}");
        }

        async void DeleteCurrentEmployee()
        {
            //Catch an error
            try
            {
                //old Employee
                var Oldemployee = await Task.FromResult(DataStore.GetEmployees.FirstOrDefault(e => e.Id == Id));
                //Remove it the list;
                DataStore.GetEmployees.Remove(Oldemployee);
                //Go back to thr prev Page
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Debug.WriteLine("Failed to Load employee");
            }
        }

        public Command DeleteEmployeeCommand { get; }
        public Command EditCommand { get; }

    }
}
