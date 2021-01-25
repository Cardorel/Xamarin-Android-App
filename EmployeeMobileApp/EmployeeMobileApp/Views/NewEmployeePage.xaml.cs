using EmployeeMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeMobileApp.Views
{
    public partial class NewEmployeePage : ContentPage
    {
        public NewEmployeePage()
        {
            InitializeComponent();
            BindingContext = new NewEmployeeViewModel();
        }
    }
}