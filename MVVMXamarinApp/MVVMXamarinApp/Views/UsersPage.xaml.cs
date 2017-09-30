using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMXamarinApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace MVVMXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        ObservableCollection<UserViewModel> Users { set; get; }

        public UsersPage()
        {
            InitializeComponent();

            Random r = new Random();

            Users = new ObservableCollection<UserViewModel>();
            foreach (var user in MockDataProvider.Users)
            {
				UserViewModel userVM = new UserViewModel(user);               
                Users.Add(userVM);
            }           
            UsersView.ItemsSource = Users;
        }

        private async void UsersView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            UserViewModel user = e.SelectedItem as UserViewModel;
            if (user != null)
            {
                await Navigation.PushAsync(new UserDetailsPage(user));
            }
        }
    }
}