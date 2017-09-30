using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMXamarinApp.Models
{
    public class UserType
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public UserType()
        {

        }

        public UserType(UserType userType)
        {
            this.Id = userType.Id;
            this.Name = userType.Name;
        }
    }
}
