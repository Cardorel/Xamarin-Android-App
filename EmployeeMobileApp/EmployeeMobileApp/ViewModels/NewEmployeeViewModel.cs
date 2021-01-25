using EmployeeMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using EmployeeMobileApp.Services;
using System.Globalization;

namespace EmployeeMobileApp.ViewModels
{
    class NewEmployeeViewModel :BaseViewModel
    {
        private string id;
        private string name;
        private string position;
        private DateTime birthday = DateTime.Now;
        private ImageSource photo = "User.jpg";

        public NewEmployeeViewModel()
        {
            SaveEmployeeCommand = new Command(SaveEmployee, IsValidate);
            CancelCommand = new Command(Cancel);
            PickImageCommand = new Command(PickImage);
            CaptureImageCommand = new Command(CaptureImage);
            PropertyChanged += (x,y) => SaveEmployeeCommand.ChangeCanExecute();
        }

        public string Id { get => id; set => SetProperty(ref id, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Position { get => position; set => SetProperty(ref position, value); }
        public DateTime Birthday { get => birthday; set => SetProperty(ref birthday, value); }
        public ImageSource Photo { get => photo; set => SetProperty(ref photo, value); }

        private bool IsValidate()
        {
            if(
                !String.IsNullOrWhiteSpace(Name) &&
                !String.IsNullOrWhiteSpace(Position)
                )
            {
                //if the input is not empty
                return true;
            }
            return false;
        }

        private async void SaveEmployee()
        {
            //add to the list
           Employee newEmployee = new Employee()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Position = Position,
                Birthday = Birthday,
                Photo = Photo
            };

            //Save in the list
            DataStore.GetEmployees.Add(newEmployee);
            await Task.FromResult(true);
            //Go back 
            await Shell.Current.GoToAsync("//EmployeesPage");

            await Task.Delay(500);
            Name = string.Empty;
            Position = string.Empty;
            Birthday = DateTime.Now;
            Photo = "User.jpg";
        }

        private async void PickImage()
        {
            //Pick a picture
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
                Title = "Please, pick an image"
            });

            //Check if isCanceled and do nothing
            if (result == null)
                return;
            await result.OpenReadAsync();
            Photo  = result.FullPath;
        }

        private async void CaptureImage()
        {
            //Capture the image
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
            {
                Title = "Please , capture an image"
            });

            if (result == null)
                return;
            //Open Gallery
            await result.OpenReadAsync();
            //set the image path
            Photo = result.FullPath;
        }

        private async void Cancel()
        {
            //Go to EmployeesPage;
            await Shell.Current.GoToAsync("//EmployeesPage");
        }

        public Command SaveEmployeeCommand { get; }
        public Command CancelCommand { get; }
        public  Command PickImageCommand { get; }
        public Command CaptureImageCommand { get; }
    }
}
