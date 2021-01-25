using EmployeeMobileApp.ViewModels;
using System;
using Xamarin.Forms;

namespace EmployeeMobileApp.Models
{
    public class Employee : BaseViewModel
    {
        private string id;
        private string name;
        private string position;
        private DateTime birthday;
        private ImageSource photo;

        public string Id { get => id; set => SetProperty(ref id , value); }
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Position { get => position; set => SetProperty(ref position, value); }
        public DateTime Birthday { get => birthday; set => SetProperty(ref birthday, value); }
        public ImageSource Photo { get => photo; set => SetProperty(ref photo, value); }
    }
}
