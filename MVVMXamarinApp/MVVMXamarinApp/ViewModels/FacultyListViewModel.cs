using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using MVVMXamarinApp.Views;

namespace MVVMXamarinApp.ViewModels
{
	public class FacultyListViewModel: INotifyPropertyChanged
	{
		public ObservableCollection<FacultyViewModel> Faculties { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand CreateFacultyCommand { private set; get; }
		public ICommand DeleteFacultyCommand { private set; get; }
		public ICommand SaveFacultyCommand { private set; get; }
		public ICommand BackCommand { private set; get; }
		private FacultyViewModel selectedFaculty;

		public INavigation Navigation { get; set; }

		public FacultyListViewModel()
		{
			Faculties = new ObservableCollection<FacultyViewModel>();
			foreach (var faculty in MockDataProvider.Faculties)
			{
				FacultyViewModel facultyVM = new FacultyViewModel(faculty);
				Faculties.Add(facultyVM);
			}		

			CreateFacultyCommand = new Command(CreateFaculty);
			DeleteFacultyCommand = new Command(DeleteFaculty);
			SaveFacultyCommand = new Command(SaveFaculty);
			BackCommand = new Command(Back);
		}

		public FacultyViewModel SelectedFaculty
		{
			get { return selectedFaculty; }
			set
			{
				if (selectedFaculty != value)
				{
					FacultyViewModel tempFaculty = value;
					selectedFaculty = null;
					OnPropertyChanged("SelectedFaculty");
					Navigation.PushAsync(new FacultyDetailsPage(tempFaculty));
				}
			}
		}

		private void CreateFaculty ()
		{
			Navigation.PushAsync(new FacultyDetailsPage(new FacultyViewModel { FacultyListViewModel = this }));
		}

		private void Back ()
		{
			Navigation.PopAsync();
		}

		private void SaveFaculty (object facultyObj)
		{
			FacultyViewModel faculty = facultyObj as FacultyViewModel;
			if (faculty != null)
			{
				if (faculty.IsValid)
				{
					Faculties.Add(faculty);
				}
				// else display alert or mb send message to display
				
			}
			// else send message or display aler that something wrong
			Back();
		}

		private void DeleteFaculty(object facultyObj)
		{
			FacultyViewModel faculty = facultyObj as FacultyViewModel;
			if (faculty != null)
			{								
				Faculties.Remove(faculty);
			}
			// else send message or display aler that something wrong
			Back();
		}
		
		protected void OnPropertyChanged (string propName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}
	}
}
