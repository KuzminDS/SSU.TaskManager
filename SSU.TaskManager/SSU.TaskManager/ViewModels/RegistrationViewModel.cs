using SSU.TaskManager.Views;
using Xamarin.Forms;


namespace SSU.TaskManager.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public Command GoBackCommand { get; }

        public RegistrationViewModel()
        {
            GoBackCommand = new Command(OnGoBackClicked);
        }

        private async void OnGoBackClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            await Shell.Current.GoToAsync($"..//{nameof(LoginPage)}");
        }
    }
}
