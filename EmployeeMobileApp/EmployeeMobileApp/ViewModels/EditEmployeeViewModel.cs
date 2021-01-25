using EmployeeMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeMobileApp.ViewModels
{
    [QueryProperty(nameof(Id) , nameof(Id))]
    class EditEmployeeViewModel: BaseViewModel
    {
        private string id;
        private string position;
        public EditEmployeeViewModel()
        {
            Title = "Edit";
            SaveModificationEmployeeCommand = new Command(Edit);
            CancelCommand = new Command(CancelModification);
        }


        private async void Edit()
        {
            //old employee where you want to Edit
            var oldEmployee = DataStore.GetEmployees.FirstOrDefault(o => o.Id == Id);
            //Check if it's not null || whiteSpace
            if (!string.IsNullOrWhiteSpace(Position))
            {
                //Change iit
                oldEmployee.Position = Position;
                //go the Employee Page
                await Shell.Current.GoToAsync("//EmployeesPage");
            }
            else
            {
                //Display war Message
                await Shell.Current.DisplayAlert("Error" , "Fill is empty, try again" , "Try again");
            }

            //Wait 1s and set the input empty
            await Task.Delay(1000);
            Position = string.Empty;

        }

        private async void CancelModification()
        {
            //Go to the prev Page;
            await Shell.Current.GoToAsync("..");
        }

        public Command SaveModificationEmployeeCommand { get; }
        public Command CancelCommand { get; }
        public string Position { get => position; set => SetProperty(ref position , value); }
        public string Id { get => id; set => SetProperty(ref id, value); }
    }
}
