using System;

namespace Mamoo.Kata.BirthdayGreetings
{
    public class Employee
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public XDate BirthDate { get; set; }

        public bool IsBirthday(XDate anotherDay)
        {
            return BirthDate.IsSameDay(anotherDay);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Employee)) return false;
            var emp = (Employee) obj;
            return emp.FirstName.Equals(this.FirstName)
                   && emp.LastName.Equals(this.LastName)
                   && emp.Email.Equals(this.Email)
                   && emp.BirthDate.Equals(this.BirthDate);
        }
    }
}