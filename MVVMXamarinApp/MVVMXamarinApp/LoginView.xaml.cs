using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMXamarinApp.ViewModels;
using MVVMXamarinApp.Views;

namespace MVVMXamarinApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{

        private UserViewModel user = new UserViewModel();

		public LoginView ()
		{
			InitializeComponent ();

            this.BindingContext = user;
		}

        private void TryLogIn(object sender, EventArgs e)
        {
			if (user.Login == "admin" && user.Password == "admin")
			{
				// navigate to new main page;
				App.Current.Properties["login"] = user.Login;
				App.Current.Properties["password"] = user.Password;
				App.Current.MainPage = new AdminMasterDetailPage();
				DisplayAlert("Helo,admin", "Хаю-хай, с вами Иван Гай", "Крутотенечка!");
			}
			else DisplayAlert("Пользователь не найден", "Пользователь с таким логином и паролем не существует", "Ясно.");
        }

        private async void GoToRegistrationPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationView());
        }

       
    }
}