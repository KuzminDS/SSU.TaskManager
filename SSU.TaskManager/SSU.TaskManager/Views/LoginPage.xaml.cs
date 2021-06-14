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
    public partial class LoginPage : ContentPage
    {
        private readonly string _dbPath;

        private string _password;

        private string _login;

        public static int IdUser { get; private set; }

        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(string dbPath)
            :this()
        {
            _dbPath = dbPath;
        }

        public async void OnRegistration_Clicked(object sender, EventArgs e)
        {
            var destination = new RegistrationPage();
            await this.Navigation.PushAsync(destination);
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var userService = DependenciesResolver.Kernel.GetService<IUserService>();
            User user = userService.GetByCondition((u) => u.Login == _login).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == _password)
                {
                    IdUser = user.Id;
                    var destination = new TabbedPageTaskList();
                    await Navigation.PushAsync(destination);
                }
                else
                {
                    await DisplayAlert("Error", "Incorrect login or password", "Ok");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Error", "Incorrect login or password", "Ok");
            }

        }

        private void Login_Completed(object sender, EventArgs e)
        {
            _login = ((Entry)sender).Text;
        }

        private void Password_Completed(object sender, EventArgs e)
        {
            _password = ((Entry)sender).Text;
        }
    }
}