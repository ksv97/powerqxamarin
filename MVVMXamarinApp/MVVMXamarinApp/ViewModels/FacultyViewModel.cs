using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using MVVMXamarinApp.Models;


namespace MVVMXamarinApp.ViewModels
{
    public class FacultyViewModel : INotifyPropertyChanged
    {		
        public Faculty Faculty { private set; get; }
		FacultyListViewModel facultyList;

        public FacultyViewModel()
        {
            Faculty = new Faculty();
        }

		public FacultyViewModel (Faculty fac)
		{
			this.Faculty = fac;
		}

		public FacultyListViewModel FacultyListViewModel
		{
			get { return facultyList; }
			set
			{
				if (facultyList != value)
				{
					facultyList = value;
					OnPropertyChanged("FacultyListViewModel");
				}
			}
		}

        public string Name
        {
            get { return Faculty.Name; }
			set
			{
				if (Faculty.Name != value )
				{
					Faculty.Name = value;
					OnPropertyChanged("Name");
				}
			}
        }

		public bool IsValid
		{
			get { return !string.IsNullOrEmpty(Name.Trim()); }			
		}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged (string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
