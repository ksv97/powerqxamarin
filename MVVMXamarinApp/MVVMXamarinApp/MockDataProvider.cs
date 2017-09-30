using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMXamarinApp.Models;

namespace MVVMXamarinApp
{
    public static class MockDataProvider
    {
        public static List<UserType> UserTypes { get; private set; }
		public static List<User> Users { get; private set; }
		public static List<Faculty> Faculties { get; private set; }

        static MockDataProvider()
        {
			Random r = new Random();

            UserTypes = new List<UserType>
            {
                new UserType
                {
                    Id = 1,
                    Name = "Руководитель",
                },
                new UserType
                {
                    Id = 2,
                    Name = "Куратор"
                },
                new UserType
                {
                    Id = 3,
                    Name = "Старший куратор"
                }
            };

			Users = new List<User>()
			{
				new User
				{
					Id = 1, FirstName = "Artem", LastName = "Grishin",
					Login = "admin", Password = "admin",
					UserType = UserTypes.SingleOrDefault(x => x.Name == "Руководитель"),
				},
				new User
				{
					Id = 2, FirstName = "Rodion", LastName = "Kosov",
					Login = "rodion", Password = "kosov",
					UserType = UserTypes.SingleOrDefault(x => x.Name == "Старший куратор")
				},
				new User
				{
					Id = 3, FirstName = "Masha", LastName = "Kolosova",
					Login = "masha", Password = "kolosova",
					UserType = UserTypes.SingleOrDefault(x => x.Name == "Куратор")
				}
			};

			Faculties = new List<Faculty>
			{
				new Faculty { Id = 1, Name = "ИВТФ+ЭМФ" },
				new Faculty { Id = 2, Name = "ТЭФ" },
				new Faculty { Id = 3, Name = "ЭЭФ" },
				new Faculty { Id = 4, Name = "ИФФ+ФЭУ" }
			};
        }
    }
}
