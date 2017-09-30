using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMXamarinApp.ViewModels;
using MVVMXamarinApp.Models;

namespace MVVMXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        public UserViewModel UserVM { set; get; }        
        
        // TODO: Make this page a Table View so it can be the same when someone's registering and when admin watches this (See "registration view")
        
        public UserDetailsPage(UserViewModel userVM)
        {
            InitializeComponent();

            UserVM = userVM;
            if (userVM == null)
            {
                UserVM = new UserViewModel();
            }

            BindingContext = UserVM;
            
            
            PositionPicker.ItemsSource = MockDataProvider.UserTypes;
            PositionPicker.ItemDisplayBinding = new Binding("Name");
            

        }

        private void PositionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserType selectedUserType = PositionPicker.SelectedItem as UserType;
            if (selectedUserType != null)
            {
                UserVM.UserType = selectedUserType;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PositionPicker.Focus();
        }

        private void PositionLabel_Focused(object sender, FocusEventArgs e)
        {
            e.VisualElement.Unfocus();
            PositionPicker.Focus();
        }
    }
}