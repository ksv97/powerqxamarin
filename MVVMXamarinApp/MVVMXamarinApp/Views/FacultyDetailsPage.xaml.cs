using MVVMXamarinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMXamarinApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FacultyDetailsPage : ContentPage
	{
		public FacultyViewModel Faculty { private set; get; }
		public FacultyDetailsPage(FacultyViewModel faculty)
		{
			InitializeComponent();
			Faculty = faculty;
			this.BindingContext = Faculty;
			
		}
	}
}