using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMXamarinApp.ViewModels;

namespace MVVMXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationView : ContentPage
    {
        public UserViewModel newUser = new UserViewModel();

        // TODO: add picker to select position (see user details page)

        public RegistrationView()
        {
            InitializeComponent();

            this.BindingContext = newUser;
        }

        private void RegisterUser(object sender, EventArgs e)
        {
            DisplayAlert("New user", $"New user entered with login = {newUser.Login}, pass = {newUser.Password}, name = {newUser.FullName}", "Cool");
        }
    }
}