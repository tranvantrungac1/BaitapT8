using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitapT8
{
    public class Employee
    {
        public String no { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public Boolean isManager { get; set; }

        public Employee()
        {
        }

        public Employee(string no, string name, string email, string password, bool isManager)
        {
            this.no = no;
            this.name = name;
            this.email = email;
            this.password = password;
            this.isManager = isManager;
        }
        public override String ToString()
        {
            return no + "," + name + "," + email + "," + isManager + "," + password;
        }
    }
}
