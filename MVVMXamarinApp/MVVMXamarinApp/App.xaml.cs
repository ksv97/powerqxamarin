using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMXamarinApp.Views;

using System.Diagnostics;
using Xamarin.Forms;

namespace MVVMXamarinApp
{
    public partial class App : Application
    {
        //public string lastUserSelected { get; private set; } = "lastUserSelected";      

        //public string FullNameOfLastSelectedUser { get; set; }

        public App()
        {
            InitializeComponent();

			//if (Properties.ContainsKey(lastUserSelected))
			//{
			//    FullNameOfLastSelectedUser = Properties[lastUserSelected] as string;
			//}
			var properties = App.Current.Properties;
			if (properties.ContainsKey("login") && (string)properties["login"] == "admin")
				MainPage = new AdminMasterDetailPage();
			else
				MainPage = new NavigationPage(new LoginView());
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
