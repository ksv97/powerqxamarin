using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMXamarinApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminMasterDetailPage : MasterDetailPage
	{
		public List<MasterPageItem> MenuList { get; set; }

		public AdminMasterDetailPage()
		{
			InitializeComponent();

			MenuList = new List<MasterPageItem>
			{
				new MasterPageItem
				{
					Title = "Пользователи",
					TargetType = typeof(UsersPage)
				},
				new MasterPageItem
				{
					Title = "Факультеты",
					TargetType = typeof(FacultyListPage)
				}
			};

			MenuListView.ItemsSource = MenuList;
			MenuListView.ItemSelected += MenuListView_ItemSelected;
		
			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FacultyListPage)));
		}

		private void MenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;			
			if (item != null)
			{
				Type page = item.TargetType;
				MenuListView.SelectedItem = null;

				Detail = new NavigationPage((Page)Activator.CreateInstance(page));
				IsPresented = false;
			}
		}

		private void Logout(object sender, EventArgs e)
		{
			var props = App.Current.Properties;
			if (props.ContainsKey("login"))
			{
				props.Remove("login");
			}
			if (props.ContainsKey("password"))
			{
				props.Remove("password");
			}
			App.Current.MainPage = new NavigationPage(new  LoginView());
		}
	}
}