using EmployeeMobileApp.Models;
using EmployeeMobileApp.Services;
using EmployeeMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeMobileApp.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {
        public Command LoadEmployeesCommand { get; }
        public ObservableCollection<Employee> Employees { get; }
        public Command EmployeeTapped { get; }
        public Command SortedCommand { get; }
        private List<Employee> employees;

        public EmployeesViewModel()
        {
            Title = "Employee";
            Employees = new ObservableCollection<Employee>();
            LoadEmployeesCommand = new Command(async () => await ExecuteLoadCommand());
            SortedCommand = new Command(async () => await SortedListEmployee());
            EmployeeTapped = new Command<Employee>(OnEmployeeSelected);
        }

        async Task SortedListEmployee()
        {
            IsBusy = true;

            try
            {
                //Clear the prev list
                Employees.Clear();
                //get current list employees
                employees = await Task.FromResult(DataStore.GetEmployees.OrderBy(x => x.Name).ToList());
                foreach (var employee in employees)
                {
                    //add each employee;
                    Employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadCommand()
        {
            IsBusy = true;

            try
            {
                Employees.Clear();
                 employees = await Task.FromResult(DataStore.GetEmployees);
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        internal void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnEmployeeSelected(Employee employee)
        {
            if(employee == null)
                return;
            //go to the employee Detail
            await Shell.Current.GoToAsync($"{nameof(EmployeeDetailPage)}?{nameof(EmployeeDetailViewModel.EmployeeName)}={employee.Name}");
        }

    }
}
