using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Sql
{
    internal class Employee
    {
        string Name;
        string brithDay;
        string email;
        int payment;
        public Employee(string Name, string brithDay, string email, int payment)
        {
            this.Name = Name;
            this.brithDay = brithDay;
            this.email = email;
            this.payment = payment;
        }
    }
}
