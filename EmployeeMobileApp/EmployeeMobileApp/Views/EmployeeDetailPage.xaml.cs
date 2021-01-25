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
  
    public partial class EmployeeDetailPage : ContentPage
    {
        public EmployeeDetailPage()
        {
            InitializeComponent();
            BindingContext = new EmployeeDetailViewModel();
        }
    }
}