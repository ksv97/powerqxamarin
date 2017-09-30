using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MVVMXamarinApp.Models;

namespace MVVMXamarinApp.ViewModels
{
	public class UserViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public User User { set; get; }

		public UserViewModel()
		{
			User = new User
			{
				UserType = new UserType()
			};
		}

		public UserViewModel(User user)
		{
			// TODO suspicious code
			User = user;
		}


		public int Id
		{
			get
			{
				return User.Id;
			}
			set
			{
				if (User.Id != value)
				{
					User.Id = value;
					OnPropertyChanged("Id");
				}
			}
		}

		public string Login
		{
			get { return User.Login; }
			set
			{
				if (User.Login != value)
				{
					User.Login = value;
					OnPropertyChanged("Login");
				}
			}
		}

		public string Password
		{
			get { return User.Password; }
			set
			{
				if (User.Password != value)
				{
					User.Password = value;
					OnPropertyChanged("Password");
				}
			}
		}

		public string FirstName
		{
			get { return User.FirstName; }
			set
			{
				if (User.FirstName != value)
				{
					User.FirstName = value;
					OnPropertyChanged("FirstName");
				}
			}
		}

		public string LastName
		{
			get { return User.LastName; }
			set
			{
				if (User.LastName != value)
				{
					User.LastName = value;
					OnPropertyChanged("LastName");
				}
			}
		}

		public string FullName
		{
			get
			{
				return User.LastName + " " + User.FirstName;
			}
		}

		public UserType UserType
		{
			get { return User.UserType; }
			set
			{
				if (User.UserType.Id != value.Id)
				{
					User.UserType = new UserType(value);
					OnPropertyChanged("UserType");
				}
			}
		}

		protected void OnPropertyChanged(string propName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}
	}
}
