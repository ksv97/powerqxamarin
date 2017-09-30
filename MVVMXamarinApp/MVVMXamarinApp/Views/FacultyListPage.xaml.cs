using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMXamarinApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMXamarinApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FacultyListPage : ContentPage
	{
		public FacultyListPage ()
		{
			InitializeComponent ();

			this.BindingContext = new FacultyListViewModel() { Navigation = this.Navigation };
		}
	}
}