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
    public partial class EmployeesPage : ContentPage
    {
        readonly EmployeesViewModel _ViewModel;
        public EmployeesPage()
        {
            InitializeComponent();
            BindingContext = _ViewModel = new EmployeesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.OnAppearing();
        }
    }
}