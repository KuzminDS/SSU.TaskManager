using SSU.TaskManager.BusinessLogic.ServiceInterface;
using SSU.TaskManager.Common.Ioc;
using SSU.TaskManager.Entities;
using SSU.TaskManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSU.TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        public RegistrationPage()
        {
            InitializeComponent();
        }
        

        public async void OnBack_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        private void Login_Completed(object sender, EventArgs e)
        {
            _login = ((Entry)sender).Text;
        }

        private void Password_Completed(object sender, EventArgs e)
        {
            _password = ((Entry)sender).Text;
        }

        private void FirstName_Completed(object sender, EventArgs e)
        {
            _firstName = ((Entry)sender).Text;
        }
        private void LastName_Completed(object sender, EventArgs e)
        {
            _lastName = ((Entry)sender).Text;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(_lastName == null || _firstName == null || _login==null || _password == null)
            {
                await DisplayAlert("Error", "All fiels must be entered", "Ok");
            }
            else
            {
                var userService = DependenciesResolver.Kernel.GetService<IUserService>();
                userService.Add(new User()
                {
                    FirstName = _firstName,
                    LastName = _lastName,
                    Login = _login,
                    Password = _password
                });
                await Navigation.PopAsync();
            }
        }
    }
}